;;;; PART 1 ;;;;;
(defun all-length(l) ;;takes a list and computes the number of atoms
    (cond
        ((null l) 0) ;;if list is empty return 0
        ((listp(car l)) (+ (all-length (car l)) (all-length (cdr l)))) ;;elif ls head is a list return recursive call of ls head + ls tail
        (t (+ 1 (all-length (cdr l)))) ;;else ls head is an atom return 1 + recursive call on the rest of l
	)
)

(defun range(l) ;takes a list and computes the range(min,max)
	(list (minl l) (maxl l)) ;passes list to minl and maxl and puts their return values in a list
)

(defun minl(l) ;;find minimum value in the list
	(if (null (cdr l)) ;;if the rest of l if null
	    (car l) ;;return l's head
	(min (car l) (minl (cdr l)))) ;else return the minimum of ls head and recursively call minl on ls rest  
)

(defun maxl(l) ;;find maximum value in the list
	(if (null (cdr l)) ;;if the rest of l if null
	    (car l) ;;return l's head
	(max (car l) (maxl (cdr l)))) ;else return the maximum of ls head and recursively call maxl on ls rest
)

(defun before(a b l) ;takes a list and return whatever is in between a and b
	(cond
		((null l) nil) ;if list in null  return null
		((and (null a) (equal (car l) b)) (cons (car l) '())) ;elif we have seen a and ls head equals b return list of ls head
		((null a) (cons (car l) (before nil b (cdr l)))) ;elif we have seen a return list of ls head and recursivly call passing (nil b ls rest)
		((equal (car l) a) (cons (car l) (before nil b (cdr l)))) ;elif ls head equals a  recursivly call passing (nil b ls head) 
		(t (before a b (cdr l))) ;else recursively call (a b ls rest)
	)
)

(defun split-if(fn l) ;takes a funtion and aa list to retrun two lists, one that evaluates false and the other true based on the function
	    (list (fl fn l '()) (tl fn l '())) ;else return a list of return values of false list and true list
)

(defun fl(fn l a) ;takes the function and list with a variable to hold the list for false values
	(cond
		((null l) a) ;if list is null return newlist with false values
		((null (car (mapcar fn (cons (car l) nil)))) (append (append a (cons (car l) '()) (fl fn (cdr l) a)))) ;elif append only if it evaluated false
		(t (fl fn (cdr l) a)) ;recurse
	)
)

(defun tl(fn l b) ;takes the function and list with a variable to hold the list for true values
	(cond
		((null l) b) ;if list is null return newlist with true values
		((null (car (mapcar fn (cons (car l) nil)))) (tl fn (cdr l) b)) ;swapped cases with false method to append only get the true values
		(t (append (append b (cons (car l) '()) (tl fn (cdr l) b)))) ;appends only if true
	)
)

(defun group(l n) ;takes a list and and number n and return a list that is grouped in sets of n with remainder at the end
    (cond
		((null l) nil) ;if list is null return nil
	    (t(group-helper l '() n)) ;else call helper funtion passing an empty string
    )
)

(defun group-helper(l nlist n) ;fills new list with correct format
	(cond
		((null l) (list nlist)) ;if list is null return list of newlist
		((eql (length nlist) n) (cons nlist (group-helper l '() n))) ;elif length of newlist is equal to n return will a append a set
		(t (group-helper (cdr l) (append nlist (list (car l))) n)) ;else return recursive call of ls rest will append remainder
	)
)

(defun mostn(fn l) ;takes a function and list to return a newlist with elements that recieved the highest score as well as the score
    (cond 
	    ((null l) nil) ;if l is null return nil
	    (t (mostn-helper fn l (maxl (mapcar fn l )) '())) ;else call helper to fill newlist and pass biggest score
    )
)

(defun mostn-helper(fn l k nlist)
	    (cond 
	    ((null l) (append (list nlist) (list k))) ;if list is null return a newlist with the filled out list with the bigest score
	    ((eql (funcall fn (car l)) k) (and (setq nlist (append nlist (list (car l)))) (mostn-helper fn (cdr l) k nlist))) ;elif check head of l and see if that score equals the biggest score if it is append the head to newlist and recurse with the rest
	    (t (mostn-helper fn (cdr l) k nlist)) ;else it is smaller so just recurse with ls rest
        )
)

;;;; PART 2 ;;;;
(defun match(l1 l2) ;takes two list and checks if they matched given that ? auto matches and atom
	(cond
		((or (null l1) (null l2)) (equal l1 l2)) ;if either l1 or l2 are null return true if l1 equals l2
		((eql (car l1) '?) (match (cdr l1) (cdr l2))) ;elif head of l1 equals ? recurse with rest of boths lists
		((and (eql (car l1) '!) (match (cdr l1) (cdr l2))) T) ;elif both head of l1 equals ! and the recursive call of l1s and l2s rest are equal return true
		((eql (car l1) '!) (match l1 (cdr l2))) ;elif head of l1 equals ! return recursive call of l1 and rest of l2
		(t (and (eql (car l1) (car l2)) (match (cdr l1) (cdr l2)))) ;else return true if l1 and l2 equal and recurse with rest of l1 and rest l2
	)

)

;;;; PART 3 ;;;;
(defun match-var(l1 l2) ;takes patterns containing pattern variables and matches them against assertions and assigns values to variables
	(unbind-var l1) ;unbind l1 since we have multiple test cases
	(match-var-helper l1 l2) ;call helper and pass unbinded l1 and l2
)

(defun unbind-var (l1)
	(cond 
		((null l1) nil) ;if l1 is null return nil
		(t (if (and (listp (car l1)) (or (eql (caar l1) '!) (eql (caar l1) '?)));else if l1s head is a list and the head->head of l1 is a ? or !
			(makunbound (cadar l1))) (unbind-var (cdr l1))) ;unbind each variable to prepare for assignment
	)
)

(defun match-var-helper(l1 l2) ;matches asertions and applies values
	(cond
		((or (null l1) (null l2)) (equal l1 l2)) ;if either l1 or l2 are null return true if l1 equals l2
		((and (listp (car l1)) (eql (caar l1) '?)) (setf (symbol-value (cadar l1)) (car l2)) (match-var-helper (cdr l1) (cdr l2))) ;elif l1s head is list and head->head-> of l1 is ? set head->tail->head of  l1 to head of l2
		((and (listp (car l1)) (eql (caar l1) '!) (match-var-helper (cdr l1) (cdr l2))) ;elif l1s head is list and head->head-> of l1 is ! and the recurseive call rest l1 rest and l2 rest is true continue to if
			(if (eql (boundp (cadar l1)) nil) (setf (symbol-value (cadar l1)) nil)) ;if head->tail->head of l1 is bound and it equals nil set head->tail->head of l1 to nil
			(setf (symbol-value (cadar l1)) (append (eval (cadar l1)) (list (car l2)))) t) ;else set head->tail->head of l1 to the evaluated values of head->tail->head
		((and (listp (car l1)) (eql (caar l1) '!)) ;elif head l1 is a list and head->head of l1 equals ! continue to if
			(if (eql (boundp (cadar l1)) nil) (setf (symbol-value (cadar l1)) nil)) ;if head->tail->head of l1 is bound and it equals nil set head->tail->head of l1 to nil
			(setf (symbol-value (cadar l1)) (append (eval (cadar l1)) (list (car l2)))) ;else set head->tail->head of l1 to the evaluated values of head->tail->head
			(match-var-helper l1 (cdr l2))) ;recurse with l1 and the rest of l2
		(t (and (eql (car l1) (car l2)) (match-var-helper (cdr l1) (cdr l2)))) ;else return true if both (head of l1 equals head of l2) and the recursive call of the rest of l1 and rest of l2
	)

)

;(print (all-length '(a (b c) (d (e f)))))
;(print (range '(0 7 8 2 3 -1)))
;(print (before 'b 'd '(a b c d)))
;(print (split-if #'(lambda (x) (> x 4)) '(1 2 3 4 5 6 7 8 9 10)))
;(print (group '(a b c d e f g) 2))
;(print (mostn #'length '((a b) (a b c) (a) (e f g))))
;(print (match '(color apple red) '(color apple red)))
;(print (match '(color apple red) '(color apple green)))
;(print (match '(color apple ?) '(color apple red)))
;(print (match '(color ? red) '(color apple red)))
;(print (match '(color ? red) '(color apple green)))
;(print (match '(! table !) '(this table supports a block)))
;(print (match '(this table !) '(this table supports a block)))
;(print (match '(! brown) '(green red brown yellow)))
;(print (match '(! brown) '(green red brown brown)))
;(print(match-var '(plus (? a) (? b)) '(plus 2 3)))
;(print a)
;(print b)
;(print (match-var '((! u) a (? v)) '(b c a d)))
;(print u)
;(print v)
;(trace match-var)
;(trace match-var-helper)
;(print (MATCH-VAR '(A (! U) A (? V) A (! W)) '(A A A A B A A)))
;(print u)
;(print v)
;(print w)
;(print (MATCH-VAR '(NIL (! U) (! V) (? W) NIL (! Y) A A)'(NIL NIL A NIL NIL A A NIL A A)))
;(print u)
;(print v)
;(print w)
;(print y)
;(print(MATCH-VAR '(NIL (! U) (! V) (? W) NIL (! Y) A A) '(NIL A NIL NIL A A NIL A A)))