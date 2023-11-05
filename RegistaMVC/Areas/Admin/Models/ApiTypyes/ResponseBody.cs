﻿namespace RegistaMVC.Areas.Admin.Models.ApiTypyes
{
    public class ResponseBody<T>
    {
        public T Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public int StatusCode { get; set; }
        public List<string> ValidationMessages { get; set; }
    }
}
