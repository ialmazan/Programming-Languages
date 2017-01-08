def get_shift():
   shift = input('Please enter a shift amount between 0 and 25: ')
   if shift.isdigit() == True:
      shift = int(shift)
      if shift > 25 or shift < 0:
         shift = get_shift()
      return shift
   else:
      shift = get_shift()
      return shift

def word():
   word = input('Please enter a string to be ciphered: ')
   word_check = word.isalpha()
   if word_check == True:
      return word, ''
   else:
      for k in range(0, len(word)):
         word_alpha = word.rstrip(' 1234567890')
      for k in range(0, len(word)):
         word_digits = word.strip(" -?+-!@#$%^&*()[]{}\|;:,.'/><abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
   return word_alpha, word_digits


def make_shift(word_alpha, shift):
  # shift = 10
#   word_alpha = 'What-did+you&say?!'
   result = ''
   for char in word_alpha:
      if ord(char) >= 65 and ord(char) <= 90:
         if ord(char) + shift > 90:
            overshift = ord(char) + shift - 91
            result += chr(65 + overshift)
         else:
            result += chr(ord(char) + shift)
      elif ord(char) >= 97 and ord(char) <=122:
         if ord(char) + shift > 122:
            overshift = ord(char) + shift - 123
            result += chr(97 + overshift)
         else:
            result += chr(ord(char) + shift)
      else:
         result += chr(ord(char))
   return result


"""
   sword = ord(char)
   sword = sword + shift
      

   if sword > 90 and sword < 97:
      sword = sword - 26
   if sword > 122 and sword <= 126:
      sword = sword - 26        
      sword = chr(sword)
      ssword += sword

   return ssword
"""

def main():
   word_alpha, word_digits = word()
   shift = get_shift()
   s = make_shift(word_alpha, shift)
   print(s + ' ' + word_digits)
      
main()

