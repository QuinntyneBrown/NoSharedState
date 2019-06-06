using System;
using System.Collections.Generic;
using System.Text;

namespace NoSharedState
{
    public interface IMyService
    {
        string Value { get; }
        int Count { get; }
    }
    public class MyService: IMyService
    {
        private readonly IContext _context;
        private int _count;
        public MyService(IContext context)
        {
            _context = context;
        }

        public string Value { get
            {
                return _context.State;
            }
        }

        public int Count
        {
            get
            {
                _count++;
                return _count;
            }
        }
    }
}
