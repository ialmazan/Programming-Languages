def doMath(n,count,alt,prev2,prev,total):
    if count <= n and count % 2 != 0:
        if alt == True:
            alt = False
            total = prev + prev2 + 1
            prev2 = prev
            prev = total
            doMath(n,count+1,alt,prev2,prev,total)
        else:
            alt = True
            total = prev + prev2 - 1
            prev2 = prev
            prev = total
            doMath(n,count+1,alt,prev2,prev,total)
    elif count <= n:
        total = prev + prev2
        prev2 = prev
        prev = total
        doMath(n,count+1,alt,prev2,prev,total)
    else:
        print(total)

while(True):       
    n = int(input("Enter n: "))
    if n == 0:
        print(1)
    elif n == 1:
        print(2)
    elif n == 2:
        print(3)
    elif n == 3:
        print(4)
    else:
        doMath(n,4,True,3,4,0)

"""
def doMath(n,alt,prev2,prev,total,count):
    if n > 3 and count % 2 != 0:
        if alt == True:
            alt = False
            total = prev + prev2 +1
            print(n,prev, prev2,total)
            prev2 = prev
            prev = total
            doMath(n-1,alt,prev2,prev,total,count+1)
        elif alt == False:
            alt = True
            total = prev + prev2 - 1
            print(n,prev, prev2,total)
            prev2 = prev
            prev = total
            doMath(n-1,alt,prev2,prev,total,count+1)
    elif n > 3:
        total = prev + prev2
        print(n,prev, prev2,total)
        prev2 = prev
        prev = total
        doMath(n-1,alt,prev2,prev,total,count+1)
    else:
        print(total)

while(True):       
    n = int(input("Enter n: "))
    if n == 0:
        print(1)
    elif n == 1:
        print(2)
    elif n == 2:
        print(3)
    elif n == 3:
        print(4)
    else:
        doMath(n,True,3,4,0,0)"""



