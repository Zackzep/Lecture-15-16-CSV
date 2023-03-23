using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lecture_15_16_CSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Player> players= new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            
            //string director = Directory.GetCurrentDirectory();
            //Directory.CurrentProject
            //MySaveToFile();
            //players.Add(new Player("Suleman", 10, "Seahawks"));
            //players.Add(new Player("Bander", 113, "Seahawks"));
            //players.Add(new Player("Will", 7, "49ers"));
            //players.Add(new Player("Zack", 34, "Packers"));

            ReadFileNoHelper();
        }

       
        public void MySaveToFile()
        {
            //File.Open is used to open specific file
            //Location is in bin->debug->net6.0
            using (var stream = File.Open(FilePaths._dataPath, FileMode.OpenOrCreate))
            {//Connection to file open
                //Tells program we will write to a file
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        //This object writes to the file
                        csv.WriteField("Zack");
                        csv.WriteField("100");
                        //Nextrecord for new line
                        csv.NextRecord();
                        csv.WriteField("Bander");
                        csv.WriteField("100");

                        //Flushes the stream(cleans residual data)
                        writer.Flush();
                    }
                }
            }//Connection to file closed
        }
        public void SaveToFile()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            

            using (var stream = File.Open(FilePaths._dataPath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                csvWriter.NextRecord();
                csvWriter.WriteField(tbFirstName.Text);
                csvWriter.WriteField(tbGrade.Text);
                writer.Flush();
            }
        }

        private void btnSaveGrade_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
        }
        public void SaveList()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = FilePaths._playerPath;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(players);
                writer.Flush();
            }
        } // SaveList

        private void btnSaveList_Click(object sender, RoutedEventArgs e)
        {
            SaveList();
        }
        //Reading CSV without helper
        public void ReadFileNoHelper()
        {
            //Get file location
            string mainDirectory = Directory.GetCurrentDirectory();
            string fileName = @"\class_data.csv";
            string filePath = mainDirectory + fileName;


            //Use StreamReader
            using (StreamReader sr = new StreamReader(filePath))
            {//Opens connection to file
                //Runs until end of file
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); // returns a line as a string
                    string[] split = line.Split(",");
                    //Formatting line display
                    foreach (string field in split)
                    {
                        runDisplay.Text += field + " ";
                    }
                    runDisplay.Text += "\n";
                }


            }//Close connection to file
        }
    }
}
