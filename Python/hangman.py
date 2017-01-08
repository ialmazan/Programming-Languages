def getWord():
    chars = set('? \t')
    word = input("Please enter a word to be guessed that does not contain ? or white space: ")
   
    if any((c in chars) for c in word):
      word = getWord()
    if not word:
      word = getWord()
    return word.lower()

def getGuess(newGuess):
    guess = input('Please enter your next guess: ')
    guess = guess.strip()
    if not guess:
      print("You must enter a guess.")
      guess = getGuess(newGuess)
    else:
	    if len(guess) > 1:
	      print("You can only guess a single character.")
	      guess = getGuess(newGuess)
	    if guess in newGuess:
	      print("You already guessed the character: " + guess)
	      guess = getGuess(newGuess)
    return guess.lower()

def printHangman(guessesTaken):
    hangman = (""," |"," |\n 0"," |\n 0\n |"," |\n 0\n/|"," |\n 0\n/|\\"," |\n 0\n/|\\\n/"," |\n 0\n/|\\\n/ \\")
    print(hangman[guessesTaken])

def play(word, guessesTaken, correctLetters, missedLetters, newGuess):
        
    while guessesTaken < 7:
           guess = getGuess(newGuess)
       
           for letter in missedLetters:
              print(letter, end=' ')
           print()

           qmark = '?' * len(word)

           if guess in word:
              correctLetters = correctLetters + guess
           else:
               if guessesTaken == 6 and guess not in word:
                   printHangman(7)
                   return print("You failed to guess the secret word: " + word)
               else:
                    guessesTaken = guessesTaken + 1

           for i in range(len(word)): # replace blanks with correctly guessed letters
              if word[i] in correctLetters:
                 qmark = qmark[:i] + word[i] + qmark[i+1:]


           if guessesTaken < 7:
                 newGuess = guess + newGuess

           if word == qmark:
               return print("You correctly guessed the secret word: " + word)
            
           printHangman(guessesTaken) 
           print(qmark)

           print("So far you have guessed: ", ", ".join(sorted(newGuess)))


def main():
    
    word = ''
    guessesTaken = 0
    correctLetters = ''
    missedLetters = ''
    newGuess = ''

    word = getWord()
    print(" \n" * 30)

    initial = '?' * len(word)
    print(initial)
    print("So far you have guessed: ")
    play(word, guessesTaken, correctLetters, missedLetters, newGuess)

main()
