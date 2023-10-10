﻿namespace SASSTS2.Application.Wrapper
{
    public class Result<T> where T : new()
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
