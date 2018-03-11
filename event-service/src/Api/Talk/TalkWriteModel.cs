using System;
namespace Api.Talk
{
    public class TalkWriteModel
    {
        public string Name { get; set; }
        public string Talker { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
