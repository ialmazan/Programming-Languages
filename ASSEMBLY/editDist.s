#Ivan Almazan #912383996
.equ wordsize, 4

.globl _start

.data
string1:
  .space 100
string2: 
  .space 100
  
string_len:
	.long 0
  
oldDist: #cost
  .space 100 * wordsize
  
curDist: #cost
  .space 100 * wordsize


.text  
  
initialize_oldDist:
movl $0, %ecx #count
movl $oldDist, %edi #pointer to oldDist 

count_oldDist:
cmpb $0, string2(%ecx) #check for null at end of string
jz end_count_oldDist #reached end of string
movl %ecx, (%edi, %ecx, wordsize) #oldDist[i] = i
incl %ecx #increment counter
jmp  count_oldDist #jump to check if at end of string

end_count_oldDist:
movl %ecx, (%edi, %ecx, wordsize) #oldDist[i] = i
movl %ecx, string_len #string length = count
ret

copy_curDist_to_oldDist:
movl $curDist, %esi #pointer to curDist
movl $oldDist, %edi #pointer to oldDist
movl string_len, %ecx #counter
incl %ecx
rep movsl #copy curDist to oldDist
ret
	
minCost: #finds the min cost
first_if:
cmpl %esi, %edi  
jge second_if
movl %edi, %esi
		
second_if:
cmpl %esi, %ebp
jge return_minCost
movl %ebp, %esi
return_minCost:
ret


_start:
#eax = i
#ebx = j
#ecx = temp
call initialize_oldDist #initialize oldDist
  
movl $1, %eax
outer_for:
cmpb $0, (string1 - 1)(%eax)
jz end_outer_for # done with for loop
movl %eax, curDist
movl $1, %ebx

inner_for:
cmpb $0, (string2 - 1)(%ebx)
jz end_inner_for #exit inner loop
movb (string2 - 1)(%ebx), %cl
cmpb (string1 - 1)(%eax), %cl
jnz diff_char #not same char so jump
movl (oldDist - wordsize)(,%ebx, wordsize), %ecx
movl %ecx, curDist(,%ebx, wordsize)
jmp end_diff_char # were the same char so skip diff char statements

diff_char:
#Calculate cost of deletion, insertion, and substitution
movl oldDist(,%ebx,wordsize), %esi
movl (curDist - wordsize)(,%ebx,wordsize), %edi
movl (oldDist - wordsize)(, %ebx, wordsize), %ebp
call minCost #check which cost the least
incl %esi #add 1 to cost
movl %esi, curDist(,%ebx, wordsize)
end_diff_char:

incl %ebx #j++
jmp inner_for

end_inner_for:
call copy_curDist_to_oldDist #do the copy
incl %eax #i++
jmp outer_for #go back and check if we loop again
end_outer_for:

movl (curDist - wordsize)(,%ebx, wordsize), %eax

done: movl %eax, %eax #this line doesn't do anything
  
