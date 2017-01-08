/* *** This file is given as part of the programming assignment. *** */

public class Parser {


    // tok is global to all these parsing methods;
    // scan just calls the scanner's scan method and saves the result in tok.
    private Token tok; // the current token
    private void scan() {
	tok = scanner.scan();
    }

    private Scan scanner;
    private SymbolTable symbols;
    Parser(Scan scanner) {
	this.scanner = scanner;
	this.symbols = new SymbolTable();
	scan();
	program();
	if( tok.kind != TK.EOF )
	    parse_error("junk after logical end of program");
    }
    
    //program ::= block
    private void program() {
    	System.out.print("#include <stdio.h>\n");
    	System.out.print("#define __EXPR(_EXPR) ( (_EXPR) <= 0 )\n\n");
    	System.out.print("int main(int argc, char **argv)\n{");
    	
        block();
        
        System.out.print("\n");
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("return 0;\n}");
    }
    
    //block ::= declaration_list statement_list    ->Also where we scope the blocks since adding variable list
    private void block(){
    	System.out.print("\n");
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("{");
        
    	symbols.beginScope();
    	declaration_list();
    	statement_list();
    	symbols.endScope(); //remove variable list since out of scope now
    	
    	System.out.print("\n");
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("}");
    }
    
    //declaration_list ::= {declaration}
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
    	halt(TK.DECLARE); // check for @ or halt at start
    	
    	System.out.print("\n");
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("int");
        
    	boolean print_comma = false;
    	do
        {
    		scan();
            String var = tok.string;
            mustbe(TK.ID);
            
            if(!symbols.add(var)) // variable already in the scope so complain
            {
                System.err.println("redeclaration of variable " + var);
            }
            else
            {
            	if(print_comma)
            		System.out.print(",");
                else
                	print_comma = true;
            	System.out.print(" ");
            	System.out.print("x_" + var + symbols.getGlobalScope());
            }
        } while( is(TK.COMMA) );
    	System.out.print(";");
    }
    
    //statement_list ::= {statement}
    private void statement_list()
    {
        while(statement());
    }

    //statement ::= assignment | print | do | if
    private boolean statement()
    {
        if(is(TK.TILDE) || is(TK.ID))
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
        System.out.print("\n");
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("printf(\"%d\\n\", ");
        expr();
        System.out.print(");");
    }

    //assignment ::= ref_id '=' expr
    private void assignment()
    {
    	System.out.print("\n");
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("");
        ref_id();
        mustbe(TK.ASSIGN);
        System.out.print("=");
        expr();
        System.out.print(";");
    }

    //ref_id ::= [ '~' [ number ] ] id -> also where we check for usage of undeclared variables
    private void ref_id()
    {
    	int scope = 0;
        boolean isTilde = is(TK.TILDE);
        if(is(TK.TILDE)) // ~
        {
            scan();
            if(is(TK.NUM))
            {
            	scope = Integer.parseInt(tok.string);
                scan();
            }
            else
            	scope = -1; // nothing so in global
        }
        String var = tok.string;
        int line = tok.lineNumber;
        mustbe(TK.ID);
        
        int inScope = symbols.search(var, scope, !isTilde);
        if(inScope == -1)
        {
            if(isTilde)
            {
                System.err.println("no such variable ~" + (scope == -1 ? "" : scope) + var + " on line " + line);
                System.exit(1);//was failing part 4 unless exit on error instead of continuing 
            }
            else
            {
                System.err.println(var + " is an undeclared variable on line " + line);
                System.exit(1);
            }
        }
        else
        {
        	System.out.print("x_" + var + inScope);
        }
    }

    //do ::= '<' guarded_command '>'
    private void do_stmt()
    {
        scan(); // <
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("while");
        guarded_command();
        mustbe(TK.ENDDO); // >
    }

    //if ::= '[' guarded_command { '|' guarded_command } [ '%' block ] ']'
    private void if_stmt()
    {
        scan(); // [
        for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
        	System.out.print("    ");
        System.out.print("if");
        guarded_command();
        while(is(TK.ELSEIF)) // |
        {
            scan();
            for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
            	System.out.print("    ");
            System.out.print("else if");
            guarded_command();
        }
        if(is(TK.ELSE)) // %
        {
            scan();
            for(int i = 0; i < symbols.getGlobalScope() + 2; i++)
            	System.out.print("    ");
            System.out.print("else");
            block();
        }
        mustbe(TK.ENDIF); // ]
    }

    //guarded_command ::= expr ':' block
    private void guarded_command()
    {
    	System.out.print(" __EXPR(");
        expr();
        System.out.print(" )");
        mustbe(TK.THEN); // :
        block();
    }

    //expr ::= term { addop term }
    private void expr()
    {
        term();
        while(addop()) // + | -
            term();
    }

    //term ::= factor { multop factor }
    private void term()
    {
        factor();
        while(multop()) // * | /
            factor();
    }

    //factor ::= '(' expr ')' | ref_id | number
    private void factor()
    {
        if( is(TK.LPAREN) ) // (
        {
            scan();
            System.out.print("(");
            expr();
            mustbe(TK.RPAREN); // )
            System.out.print(")");
        }
        else if(is(TK.TILDE) || is(TK.ID))
            ref_id();
        else
        {
        	String var = tok.string;
            mustbe(TK.NUM);
            System.out.print(var);
        }
    }

     //addop ::= '+' | '-'
    private boolean addop() {
        if(is(TK.PLUS) || is(TK.MINUS)) // + | -
        {
        	System.out.print(" ");
        	System.out.print(tok.string);
        	System.out.print(" ");
            scan();
            return true;
        }
        return false;
    }

    //multop ::= '*' | '/'
    private boolean multop() {
        if(is(TK.TIMES) || is(TK.DIVIDE)) // * /
        {
        	System.out.print(" ");
        	System.out.print(tok.string);
        	System.out.print(" ");
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
    private void mustbe(TK tk)
    {
        halt(tk);
        scan();
    }

    private void halt(TK tk)
    {
        if( tok.kind != tk ) {
            System.err.println( "mustbe: want " + tk + ", got " +
                        tok);
            parse_error( "missing token (mustbe)" );
        }
    }

    private void parse_error(String msg) {
	System.err.println( "can't parse: line "
			    + tok.lineNumber + " " + msg );
	System.exit(1);
    }
}
