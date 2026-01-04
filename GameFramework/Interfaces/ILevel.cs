using GameFrameWork.Core;

namespace JungleEscapeGame.Levels
{
    public interface ILevel
    {
        Player Player { get; }
        void Load(Game game);
        void UpdateBullets(GameTime gameTime, Game game);
    }
}