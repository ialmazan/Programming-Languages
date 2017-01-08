//Ivan Almazan #912383996
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv){
	unsigned int dividend = 0, divisor = 0, quotient = 0, remainder = 0, bits = 0, tempa = 0, tempb = 0, temp = 0;

	sscanf(argv[1], "%u", &dividend);
	sscanf(argv[2], "%u", &divisor);

	if (dividend == 0){}	
	else{

		tempa = dividend; //Get number of bits
		while (tempa > 0){
			tempa >>= 1;
			bits++;
		}

		tempa = dividend;  //Reverse Bits
		while (tempa > 0){
			tempb = (tempb << 1) | (tempa & 1);
			tempa >>= 1;
		}
		tempa = tempb;
		tempb = divisor;
		temp = 0;
		for (unsigned int i = bits; i > 0; tempa >>= 1, i--){   //Do Division

			temp = (temp << 1) | (tempa & 1);
			if (temp >= tempb){//can divide
				temp -= tempb; //subtract out divisor
				quotient = (quotient << 1) | 1; //bring in 1
			}
			else{
				quotient <<= 1; //bring in 0
			}
			remainder = temp;
		}
	}

	printf("%u / %u = %u R %u\n", dividend, divisor, quotient, remainder);
	return 0;
}
