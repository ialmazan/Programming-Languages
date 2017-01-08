//Ivan Almazan #912383996

#include "MyFloat.h"

MyFloat::MyFloat(){
  sign = 0;
  exponent = 0;
  mantissa = 0;
}

MyFloat::MyFloat(float f){
  unpackFloat(f);
}

MyFloat::MyFloat(const MyFloat & rhs){
	sign = rhs.sign;
	exponent = rhs.exponent;
	mantissa = rhs.mantissa;
}

ostream& operator<<(std::ostream &strm, const MyFloat &f){
	strm << f.packFloat();
	return strm;
}

//Overloads == operator to make main work
bool MyFloat::operator==(const float rhs) const{
	return packFloat() == rhs;
}

void MyFloat::unpackFloat(float f) {
	__asm__(
		"andl $0x7F800000, %[exponent];"
		"shrl $31, %[sign];"
		"shrl $23, %[exponent];"
		"andl $0x7FFFFF, %[mantissa];"
		"subl $127, %[exponent]":
	"=b" (this->mantissa), "=a" (this->sign), "=c" (this->exponent) :// outputs
		[mantissa] "b" (f), [sign] "a" (f), [exponent] "c" (f) :
		"cc"
		);
}//unpackFloat

float MyFloat::packFloat() const{
	float f = 0;
	__asm__(
		"movl $0, %[f];"
		"shll $31, %[sign];"
		"or %[sign], %[f];"
		"addl $127, %[exponent];"
		"shll $23, %[exponent];"
		"or %[exponent], %[f];"
		"or %[mantissa], %[f]"
		:
	[f] "=D" (f) :
		[mantissa] "b" (this->mantissa), [sign] "a" (this->sign), [exponent] "c" (this->exponent) :
		"cc"
		);
	return f;
}//packFloat

MyFloat MyFloat::operator+(const MyFloat& rhs) const
{
  MyFloat result, larger, smaller;

  int appendMask = 0x800000;
  int removeMask =  0x7FFFFF;

  if (this->exponent == rhs.exponent && this->mantissa == rhs.mantissa && this->sign != rhs.sign)
    return 0;

  if (this->exponent > rhs.exponent){      // lhs > rhs
    larger = *this;
    smaller = rhs;
  }
  else if (rhs.exponent > this->exponent){ // rhs > lhs
    larger = rhs;
    smaller = *this;
  }
  else                                    // rhs == lhs
  {
    if(rhs.mantissa > this->mantissa){    // if same exponent, compare mantissa
      larger = rhs;
      smaller = *this;
    }
    else{
      larger = *this;
      smaller = rhs;
    }
  }
  
  larger.mantissa |= appendMask;
  smaller.mantissa |= appendMask;
  
  int difference = larger.exponent - smaller.exponent;
  
  if (difference <= 8){
	  larger.mantissa <<= difference;
	  larger.exponent -= difference;

	  result.sign = larger.sign;
	  result.exponent = larger.exponent;

	  if (larger.sign != smaller.sign){ //find which mantissa is larger, subtract larger mantissa 
		  result.mantissa = larger.mantissa - smaller.mantissa;
	  }
	  else{
		  result.mantissa = larger.mantissa + smaller.mantissa;
		  if (carryWouldHappen(larger.mantissa, smaller.mantissa)){
			  result.exponent += 1;
			  result.mantissa >>= 1;
			  result.mantissa |= (1 << 31);
		  }
	  }

	  while (result.mantissa > 16777215){ // normalize
        result.mantissa >>= 1;
        result.exponent++;
      }

      while(result.mantissa < 8388608 && result.exponent != 0){
        result.mantissa <<= 1;
        result.exponent --;
      }

      result.mantissa &= removeMask; // remove the leading 1
      
      return result;
    }
    else{ // difference > 8
      smaller.mantissa >>= difference;
      smaller.exponent += difference;

      result.sign = larger.sign;
      result.exponent = smaller.exponent;

      if(larger.sign != smaller.sign) // find which mantissa is larger, subtract larger mantissa
        result.mantissa = larger.mantissa - smaller.mantissa;
      else
        result.mantissa = larger.mantissa + smaller.mantissa;
      
      while(result.mantissa > 16777215){ // normalize
        result.mantissa >>= 1;
        result.exponent++;
      }

      result.mantissa &= removeMask;

      return result;
    }
}

MyFloat MyFloat::operator-(const MyFloat& rhs) const
{
  MyFloat rhs_copy(rhs);

  if (rhs_copy.sign == 0)
     rhs_copy.sign = 1;
  else
     rhs_copy.sign = 0;

  return *this + rhs_copy;
}

bool MyFloat::carryWouldHappen(unsigned int a, unsigned int b){
  bool carry = false;

  __asm__(
    "movl $0, %%eax;"
  	"addl %%ecx, %%edx;"                
  	"jnc done;"
  	"movl $1, %%eax;"                   
  	"done:"
  	:
  	"=a" (carry):
  	"c" (a), "d" (b):
  );

  return carry;
} // carryWouldHappen
