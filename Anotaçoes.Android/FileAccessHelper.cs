using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Anotaçoes.Droid
{
    internal class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            // junta o nome do arquivo a ser salvo como db com o caminho onde sera salvo
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
            // retorna algo como /usr/var/app/data.db
        }
    }
}