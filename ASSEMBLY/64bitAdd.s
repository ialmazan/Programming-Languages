#Ivan Almazan #912383996
.global _start

.equ wordsize, 4

.data
num1: #array of num1
	.long -3 #upper
	.long 1035789 #lower

num2:  #array of num2
	.long -1 #upper
	.long 4785124 #lower
	
.text

_start:

movl $0, %esi #i=0
movl num1(,%esi, wordsize), %edx #num1Upper into ebx //num1[0] = edx
movl num2(,%esi, wordsize), %ebx #num2Upper into edx //num2[0] = ebx
incl %esi #i++
movl num1(,%esi, wordsize), %ecx #num1Lower into eax //num1[1] = ecx
movl num2(,%esi, wordsize), %eax #num2Lower into ecx //num2[1] = eax

#we have pairs edx:ecx and ebx:eax where ecx and eax are the lower 32 bits of the two numbers

add %ecx,%eax #add lower values and put result in eax
adc %ebx,%edx #add with carry upper and put result in edx

done: 
movl %eax, %eax

