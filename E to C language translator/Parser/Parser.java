/* *** This file is given as part of the programming assignment. *** */

public class Parser {


    // tok is global to all these parsing methods;
    // scan just calls the scanner's scan method and saves the result in tok.
    private Token tok; // the current token
    private void scan() {
	tok = scanner.scan();
    }

    private Scan scanner;
    Parser(Scan scanner) {
	this.scanner = scanner;
	scan();
	program();
	if( tok.kind != TK.EOF )
	    parse_error("junk after logical end of program");
    }

    private void program() {
	block();
    }

    private void block(){
	declaration_list();
	statement_list();
    }

    private void declaration_list() {
	// below checks whether tok is in first set of declaration.
	// here, that's easy since there's only one token kind in the set.
	// in other places, though, there might be more.
	// so, you might want to write a general function to handle that.
	while( is(TK.DECLARE) ) {
	    declaration();
	}
    }
    
 	//assignment ::= ref_id '=' expr
    private void declaration() {
	mustbe(TK.DECLARE);
	mustbe(TK.ID);
	while( is(TK.COMMA) ) {
	    scan();
	    mustbe(TK.ID);
	}
    }
    
    //statement_list ::= {statement}
    private void statement_list()
    {
        while(statement());
    }

    //statement ::= assignment | print | do | if
    private boolean statement()
    {
        if(is_ref_id())
            assignment();
        else if(is(TK.PRINT)) // !
            print();
        else if(is(TK.DO)) // <
            do_stmt();
        else if(is(TK.IF)) // [
            if_stmt();
        else
            return false;
        return true;
    }

    //print ::= '!' expr
    private void print()
    {
        scan(); // !
        expr();
    }

    //assignment ::= ref_id '=' expr
    private void assignment()
    {
        ref_id();
        mustbe(TK.ASSIGN);
        expr();
    }

    //ref_id ::= [ ' ' [ number ] ] id
    private void ref_id()
    {
        if(is(TK.TILDE)) // ~
        {
            scan();
            if(is(TK.NUM))
                scan();
        }
        mustbe(TK.ID);
    }

    //helper function
    private boolean is_ref_id()
    {
        return is(TK.TILDE) || is(TK.ID);
    }

    //do ::= '<' guarded_command '>'
    private void do_stmt()
    {
        scan(); // <
        guarded_command();
        mustbe(TK.ENDDO); // >
    }

    //if ::= '[' guarded_command { '|' guarded_command } [ '%' block ] ']'
    private void if_stmt()
    {
        scan(); // [
        guarded_command();
        while(is(TK.ELSEIF)) // |
        {
            scan();
            guarded_command();
        }
        if(is(TK.ELSE)) // %
        {
            scan();
            block();
        }
        mustbe(TK.ENDIF); // ]
    }

    //guarded_command ::= expr ':' block
    private void guarded_command()
    {
        expr();
        mustbe(TK.THEN); // :
        block();
    }

    //expr ::= term { addop term }
    private void expr()
    {
        term();
        while(addop()) // + -
            term();
    }

    //term ::= factor { multop factor }
    private void term()
    {
        factor();
        while(multop()) // * /
            factor();
    }

    //factor ::= '(' expr ')' | ref_id | number
    private void factor()
    {
        if( is(TK.LPAREN) ) // (
        {
            scan();
            expr();
            mustbe(TK.RPAREN); // )
        }
        else if(is_ref_id())
            ref_id();
        else
            mustbe(TK.NUM);
    }
    
    //addop ::= '+' | '-'
    private boolean addop() {
        if(is(TK.PLUS) || is(TK.MINUS)) // + -
        {
            scan();
            return true;
        }
        return false;
    }

    //multop ::= '*' | '/'
    private boolean multop() {
        if(is(TK.TIMES) || is(TK.DIVIDE)) // * /
        {
            scan();
            return true;
        }
        return false;
    }

    // is current token what we want?
    private boolean is(TK tk) {
        return tk == tok.kind;
    }

    // ensure current token is tk and skip over it.
    private void mustbe(TK tk) {
	if( tok.kind != tk ) {
	    System.err.println( "mustbe: want " + tk + ", got " +
				    tok);
	    parse_error( "missing token (mustbe)" );
	}
	scan();
    }

    private void parse_error(String msg) {
	System.err.println( "can't parse: line "
			    + tok.lineNumber + " " + msg );
	System.exit(1);
    }
}
