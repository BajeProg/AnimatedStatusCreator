using System.Collections.Generic;

namespace AnimatedStatusCreator
{
    internal class StatusObject
    {
        public int timeout;
        public List<Text> animation = new List<Text>();

        public StatusObject(int timeout) => this.timeout = timeout;

        public void AddText(Text text) => animation.Add(text);
    }
}
