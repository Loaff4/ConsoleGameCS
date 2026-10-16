using ConsoleGame.Items.Data;

namespace ConsoleGame.Items;

public class EmptyTool : Tool 
{
    public EmptyTool(ToolData data) : base (ToolData.Empty)
    {
        
    }
}