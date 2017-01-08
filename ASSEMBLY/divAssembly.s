#Ivan Almazan #912383996

.globl _start

.equ wordsize, 4

.data
dividend:
  .long 64
divisor: 
  .long 4
bits:
  .long 0
rBits:
  .long 0
quotient:
  .long 0
remainder:
  .long 0

.text  

_start:
movl quotient, %eax
movl bits, %ebx
movl dividend, %ecx
movl remainder, %edx
movl rBits, %esi
movl divisor, %edi
#ebp is free for temps
cmpl $0, %ecx #if (dividend == 0)
jnz setup1 #if not zero jump to setup1
jmp done #it was zero skip to done

setup1:
movl %ecx, %edx #remainder = dividend

getBits:
cmpl $0, %edx #if (remainder > 0)
jbe end_getBits #exit getBits
shrl $1, %edx #remainder >>= 1;
inc %ebx #bits++
jmp getBits
end_getBits:

reverseBits:
cmpl $0, %ecx #if (dividend > 0)
jbe end_reverseBits #exit reverseBits
shll $1, %esi #esi = (reverseBits << 1)
movl %ecx, %ebp #temp = dividend
andl $1, %ebp #ebp = (temp & 1)
orl %ebp, %esi #esi = (esi|ecx) = rBits
shrl $1, %ecx #dividend >>= 1;
jmp reverseBits
end_reverseBits:

movl $0, %edx #remainder = 0
movl $0, %ebp #temp = 0
for:
cmpl $0, %ebx #if (bits > 0)
jz done #exit for loop
shll $1, %edx #edx = (remainder << 1)
movl %esi, %ebp #temp = rBits
andl $1, %ebp #ebp = (temp & 1)
orl %ebp, %edx #edx = (edx|ebp) = remainder

cmpl %edi, %edx #if (remainder >= divisor)
jb else #go to else statement
subl %edi, %edx
shll $1, %eax #eax = (quotient << 1)
orl $1, %eax #eax = (eax|1) = quotient
shrl $1, %esi #rBits >>= 1;
dec %ebx #bits--
jmp for
else:
shll $1, %eax #eax = (quotient << 1)
shrl $1, %esi #rBits >>= 1;
dec %ebx #bits--
jmp for


done: movl %eax, %eax #this line doesn't do anything
  
