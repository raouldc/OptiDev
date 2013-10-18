using System;
using System.Drawing;

namespace P02Project.DataFetcher
{
    class DataItem
    {
        protected String title;
        protected String link;
        protected String description;
        protected Image image;

        public DataItem(String title, String link, String description, Image image)
        {
            this.title = title;
            this.link = link;
            this.description = description;
            this.image = image;
        }
    }
}
