/* Part 1 */

fc_course(Course) :- /*Course resolves true when it is a 3 or 4 unit course and prereqs don't matter*/
    course(Course, _, Units),
    (Units=3;Units=4).

prereq_110(Course) :- /*Course resolves true when ecs110 is a member of the list prereqs and units don't matter*/
    course(Course, Prereqs, _),
    member(ecs110, Prereqs).

ecs140a_students(Name) :- /*Name resolves true when ecs140a is a member of the list Courses*/
    student(Name, Courses),
    member(ecs140a, Courses).

instructor_names(Instructor) :- /*Instructor resolves true when teach_john resolves true*/
    instructor(Instructor, _),
    teach_john(Instructor).

teach_john(Instructor) :- /*Instructor resolves true when Course is a member of both the lists student courses and instructor courses using cut*/
    student(john, StudentCourses),
    instructor(Instructor, InsCourses),
    member(Course, InsCourses),
    member(Course, StudentCourses), !.

students(Student) :- /*Similar to part d but list evaluation is swapped and we use jim list instead of johns*/
    student(Student, _),
    jim_student(Student).

jim_student(Student) :-
    instructor(jim, InsCourses),
    student(Student, StudentCourses),
    member(Course, StudentCourses),
    member(Course, InsCourses), !.

allprereq(Course, Prereqs) :- /* find all prereqs for a given course and the prereqs of prereqs*/
    findall(CC,(course(CC,_,_),prereq([Course],CC)),Prereqs).
    
prereq([Course|Courses], Prereqs) :-
    course(Course, ImmPrereqs, _),
    (member(Prereqs, ImmPrereqs);
    prereq(Courses, Prereqs);
    prereq(ImmPrereqs, Prereqs)).

/* Part 2 */

all_length([], 0). /* 0 when empty  base case*/

all_length([H|T], L) :- /* true when H is atom len+1*/
    atom(H), all_length(T, LenT), L is LenT + 1.

all_length([[H|TH]|T], L) :- /*recurse for the rest */
    atom(H) -> all_length(TH, LenTT), all_length(T, LenTTT), L is LenTT + LenTTT + 1; /* if atom add on to the length*/
    all_length(H, LenT), all_length(TH, LenTT), all_length(T, LenTTT), L is LenT + LenTT + LenTTT. /*else recurse and add all lenghts */

equal_a_b(L):-equal_help(L, 0, 0). /*true when equal help is true*/
equal_help([], Acount, Acount). /*base case yes when empty*/
equal_help([X|T], Acount, Bcount):- /* true when a nd b are equal*/
    X = a -> (TempA is Acount + 1, equal_help(T, TempA, Bcount)); /*if x = a increase store a count and recurse */
    X = b -> (TempB is Bcount + 1, equal_help(T, Acount, TempB)); /*if x = b increase store b count and recurse */
    equal_help(T, Acount, Bcount). /* else recurse*/

swap_prefix_suffix(K, L, S):- /* True if k is sublist of L and S is the result with of splitting and swapping the suffix with prefix with K in between.*/
    append3(Prefix, K, Suffix, L),
    append3(Suffix, K, Prefix, S).
    
append3(L1, L2, L3, L):-
    append(L1, LL, L), append(L2, L3, LL).

palin(L):- /*true when sting is equal both fowards and backwards.*/
    my_reverse(L, R),
    equal_lists(L, R).
    
my_reverse([],[]). /* base case */
my_reverse([H|T],LR):- /* reverse string */
    my_reverse(T, TR),
    append(TR, [H], LR).

equal_lists([], []). /* base case */
equal_lists([H1|L1], [H2|L2]):-
    H1 == H2, equal_lists(L1, L2).

good([0]). /*base case we have only 0*/
good([H|T]):- /* we have a one check for two more good seqs*/
    H == 1, check(T).

check(L):- /* true if we have two more good sequences in susscesion*/
    append(X, Y, L),
    good(X),
    good(Y).
