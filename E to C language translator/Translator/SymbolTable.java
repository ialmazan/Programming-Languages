import java.util.*;

public class SymbolTable
{
    private Stack<ArrayList<String>> stack;

    public SymbolTable()
    {
        stack = new Stack<ArrayList<String>>();
    }

    public int getGlobalScope()
    {
        return stack.size() - 1;
    }

    public void beginScope()
    {
        stack.push(new ArrayList<String>());
    }

    public void endScope()
    {
        stack.pop();
    }

    public boolean add(String var)
    {
        if(this.contains(var, 0, false))
        {
            return false;
        }
        else
        {
            stack.peek().add(var);
            return true;
        }
    }

    public boolean contains(String var, int scope, boolean recursive)
    {
        return search(var, scope, recursive) != -1;
    }

    public int search(String var, int scope, boolean recursive)
    {
        if(scope == -1) scope = this.getGlobalScope();
        int index = this.getGlobalScope() - scope;
        for(int i = index; i >= 0; i--)
        {
            ArrayList<String>vars = stack.elementAt(i);
            for(String iVar : vars)
            {
                if(var.equals(iVar))
                    return i;
            }
            if(!recursive) break; //lol not really recursive but w/e
        }
        return -1;
    }
}
