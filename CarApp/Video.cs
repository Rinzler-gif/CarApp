﻿namespace CarApp
{
    public class Video
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}