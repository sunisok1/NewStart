namespace Assets.Scripts.Game.Core
{
    public class PlayerFactory
    {
        public static Player CreatePlayer(string name)
        {
            // 在这里可以添加逻辑来自定义创建Player的过程
            return new Player()
            {
                data = new()
                {
                    Name = name
                }
            };
        }
    }
}