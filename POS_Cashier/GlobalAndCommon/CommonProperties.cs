using System;

namespace Pos_API.GlobalAndCommon
{
    public class CommonProperties
    {
        public string Created { get; set; } = DateTime.Now.ToString();
        public string Updated { get; set; } = DateTime.Now.ToString();
        public string? Message { get; set; }
    }
}
