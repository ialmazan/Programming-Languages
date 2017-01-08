def getContents(file):
    contents = []
    with open(file) as f:
        while True:
            c = f.read(1)
            if not c:
                break
            contents.append(c)
    f.close()
    return contents

def diff(contents1,contents2,fname1,fname2):
    count = 0
    if len(contents1) < len(contents2):
        slength = len(contents1)
        blength = len(contents2)
        fname = fname2
        bigger = contents2
    else:
        slength = len(contents2)
        blength = len(contents1)
        fname = fname1
        bigger = contents1
        
    while count < slength:
        if contents1[count] != contents2[count]:
            print('Mismatch at character {} {} != {}'.format(count,contents1[count],contents2[count]))
        count +=1
    while count < blength:
        print('No matching character for character {} ({}) found in {}.'.format(count,bigger[count],fname))
        count +=1

def main():
    fname1 = input('Enter the name of the first file: ')
    fname2 = input('Enter the name of the second file: ')
    contents1 = getContents(fname1)
    contents2 = getContents(fname2)
    diff(contents1,contents2,fname1,fname2)
    
main()


