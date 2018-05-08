using System;
using System.IO;

namespace Convierte_a_DXF
{
    /**
     * Converts text files with points, plots the number and cota
     * */
    public static class Convertidor
    {
        static TextReader input = Console.In;
        //DXF HEADERS
        const string DXFStart = "0\nSECTION\n2\nENTITIES";
        const string DXFEOF = " \n0\nENDSEC\n0\nEOF";

        //DXF ENTITIES
        const string DXFPoint = "\n0\nPOINT\n5\n_E_\n100\nAcDbEntity\n8\nPunto\n100\nAcDbPoint\n10\n_X_\n20\n_Y_\n30\n_Z_";
        const string DXFText = "\n0\nTEXT\n5\n_E_\n100\nAcDbEntity\n8\nPuntoNum\n100\nAcDbText\n10\n_X_\n20\n_Y_\n30\n_Z_\n40\n0.005\n1\n_T_\n100\nAcDbText";
        const string DXFCota = "\n0\nTEXT\n5\n_E_\n100\nAcDbEntity\n8\nPuntoCota\n100\nAcDbText\n10\n_X_\n20\n_Y_\n30\n_Z_\n40\n0.0025\n1\n_T_\n100\nAcDbText";

        //GENERAL PARAMETERS
        static int entityNum = 20;
        static char separator = ',';
        static int xPos = 1;
        static int yPos = 2;
        static int zPos = 3;

        /**
         * Converts and saves the file to the same path as origin, using the specified order and separator
         * */
        public static int Convert(string path, int order)
        {
            string inString = "";
            string dxfString = "";
            string fileName = "_";
            string fileDirectory = "_";
            
            //Ensuring file exists
            if (path != "")
            {
                if (File.Exists(path))
                {
                    input = File.OpenText(path);
                    fileDirectory = Path.GetDirectoryName(path);
                    fileName = Path.GetFileNameWithoutExtension(path);
                }
            }
            else
            {
                return 1;
            }

            //Setting up order to use
            if(order == 0)
            {
                xPos = 1;
                yPos = 2;
            }
            else if (order == 1)
            {
                xPos = 2;
                yPos = 1;
            }

            // Getting lines from input
            for (string line; (line = input.ReadLine()) != null;)
            {
                inString += line + "\n";
            }

            //If the lines contains text
            if (inString != "")
            {
                //Setting separator
                if (inString.Contains(","))
                {
                    separator = ',';
                }
                else if (inString.Contains(";"))
                {
                    separator = ';';
                }
                else
                {
                    separator = '\t';
                }

                //Converts text to the dxf format
                dxfString = getDXFString(inString);
                dxfString = dxfString.Trim();

                //Saves the file
                File.WriteAllText(@"" + fileDirectory + @"\" + fileName + ".dxf", dxfString);

            }
            return 0;
        }

        /**
         * Converts the specified file to dxf, assuming the order is PXYZ
         * */
        public static int Convert(string path)
        {
            string inString = "";
            string dxfString = "";
            string fileName = "_";
            string fileDirectory = "_";
            int order = 0;
            
            //Ensuring file existance
            if (path != "")
            {
                if (File.Exists(path))
                {
                    input = File.OpenText(path);
                    fileDirectory = Path.GetDirectoryName(path);
                    fileName = Path.GetFileNameWithoutExtension(path);
                }
            }
            else
            {
                return 1;
            }

            //Setting order
            if (order == 0)
            {
                xPos = 1;
                yPos = 2;
            }
            else if (order == 1)
            {
                xPos = 2;
                yPos = 1;
            }

            //Getting lines from input
            for (string line; (line = input.ReadLine()) != null;)
            {
                inString += line + "\n";
            }

            //If the string isn't empty
            if (inString != "")
            {
                //Setting separator
                if (inString.Contains(","))
                {
                    separator = ',';
                }
                else if (inString.Contains(";"))
                {
                    separator = ';';
                }
                else
                {
                    separator = '\t';
                }

                //Converts text to dxf representation
                dxfString = getDXFString(inString);
                dxfString = dxfString.Trim();

                //Saving the file
                File.WriteAllText(@"" + fileDirectory + @"\" + fileName + ".dxf", dxfString);

            }
            return 0;
        }

        //Gets the dxf representation of a points list
        static string getDXFString(string inString)
        {
            string dxfString = "";
            string[] lines = inString.Split(new string[] { "\n", "\r\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            dxfString += DXFStart;

            //Reading throug points
            foreach (string line in lines)
            {
                string newLine = line.Trim();
                dxfString += getDXFPoint(newLine);
                dxfString += getDXFLabel(newLine);
                dxfString += getDXFCota(newLine);
            }

            //Appending EOF
            dxfString += DXFEOF;
            return dxfString;
        }

        //Returns a dxf representation of a point
        static string getDXFPoint(string line)
        {
            
            string[] coords = line.Split(separator);

            string p = "" + DXFPoint;

            p = p.Replace("_X_", coords[xPos]);
            p = p.Replace("_Y_", coords[yPos]);
            p = p.Replace("_Z_", coords[zPos]);
            p = p.Replace("_E_", "" + entityNum);

            entityNum++;

            return p;
        }

        //Return a dxf representation of a text, for setting up the point number
        static string getDXFLabel(string line)
        {
 
            string[] coords = line.Split(separator);
            string p = "" + DXFText;
            string txt = "";
            double number;
        
            double x = Double.Parse(coords[xPos]);
            double y = Double.Parse(coords[yPos]);

            if (Double.TryParse(coords[0], out number))
                txt = number.ToString();
            else
                txt = coords[0];


            x += 0.003;
            y += 0.003;

            p = p.Replace("_X_", x.ToString());
            p = p.Replace("_Y_", y.ToString());
            p = p.Replace("_Z_", coords[zPos]);
            p = p.Replace("_T_", txt);
            p = p.Replace("_E_", "" + entityNum);

            entityNum++;

            return p;
        }

        //Return a dxf representation of a text, to set up cota label of point
        static string getDXFCota(string line)
        {
            string[] coords = line.Split(separator);

            string p = "" + DXFCota;

            double x = Double.Parse(coords[xPos]);
            double y = Double.Parse(coords[yPos]);

            x += 0.003;
            y -= 0.003;

            p = p.Replace("_X_", x.ToString());
            p = p.Replace("_Y_", y.ToString());
            p = p.Replace("_Z_", coords[zPos]);
            p = p.Replace("_T_", coords[zPos]);
            p = p.Replace("_E_", "" + entityNum);

            entityNum++;

            return p;
        }
    }
}
