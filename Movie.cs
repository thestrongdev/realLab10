using System;
using System.Collections.Generic;
using System.Text;

namespace theRealLab10
{
    class Movie
    {
        private string _title;
        private string _category;

        public string Title { get => _title; set => _title = value; }
        public string Category { get => _category; set => _category = value; }

        public Movie(string title, string category)
        {
            _title = title;
            _category = category;
        }
    }
}
