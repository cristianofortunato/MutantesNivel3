using System;
using System.Collections.Generic;
using Classes;
namespace Mutantes
{
    public class functions
    {


        public bool InputValid(char s)
        {
            bool ValidInput = true;
            if ((s != 'A') && (s != 'T') && (s != 'C') && (s != 'G'))
            {
                ValidInput = false;

            }
            return ValidInput;
        }

        private int maxH(string[] values)
        {
            int size = 0;
            size = values.Length;
            return size;
        }

        private int maxW(string[] values)
        {
            int size = 0;
            foreach (string s in values)
            {
                char[] letters = s.ToCharArray();
                if (letters.Length > size)
                {
                    size = letters.Length;
                }
            }
            return size;
        }

        private int HorizontalTest(int H, int W, char[,] mDNA){
            int HorizontalMatch = 0;
            for (int j = 0; j < H; j++)
                {
                for (int i = 0; i < W; i++)
                    {
                    if (W - (i + 4) >= 0)
                        {
                            if ((mDNA[j, i] == mDNA[j, (i + 1)]) && (mDNA[j, i] == mDNA[j, (i + 2)]) && (mDNA[j, i] == mDNA[j, (i + 3)]))
                            {
                            HorizontalMatch++;
                            }
                        }
                    }
                }
            return HorizontalMatch;
        }

     

        private int VerticalTest(int H, int W, char[,] mDNA)
        {
            int VerticallMatch = 0;
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (H - (j + 4) >= 0)
                    {
                        if ((mDNA[j, i] == mDNA[(j+1), i]) && (mDNA[j, i] == mDNA[(j+2), i]) && (mDNA[j, i] == mDNA[(j+3), i]))
                        {
                            VerticallMatch++;
                        }
                    }
                }
            }
            return VerticallMatch;
        }

        private int DiagonalTest(int H, int W, char[,] mDNA)
        {
            int DiagonalMatch = 0;
            for (int j = 0; j < H; j++)
            {
                for (int i = 0; i < W; i++)
                {
                    if ((H - (j + 4) >= 0) && (W - (i + 4) >= 0))
                    {
                        if ((mDNA[j, i] == mDNA[(j + 1), (i + 1)]) && (mDNA[j, i] == mDNA[(j + 2), (i + 2)]) && (mDNA[j, i] == mDNA[(j + 3), (i + 3)]))
                        {
                            DiagonalMatch++;
                        }
                    }
                }
            }
            return DiagonalMatch;
        }

        public bool isMutant(Classes.Mutant _person){
            bool ismutant = false;
            bool invalidValue = false;
            char[,] mDNA = new char[maxH(_person.DNA),maxW(_person.DNA)];
            int col = 0;
            foreach (string s in _person.DNA)
            {
                int line = 0;
                foreach(char c in s.ToCharArray())
                {
                    if (InputValid(c))
                    {
                        mDNA[col, line] = c;
                    }
                    else{
                        invalidValue = true;
                        break;
                    }
                    line++;
                }
                col++;
            }
            if (!invalidValue)
            {
                int validDNA = 0;
                int H = maxH(_person.DNA);
                int W = maxW(_person.DNA);

                //horizontal test
                validDNA = validDNA + HorizontalTest(H, W, mDNA);

                //vertical test
                validDNA = validDNA + VerticalTest(H, W, mDNA);
               
                //diagonal test
                validDNA = validDNA + DiagonalTest(H, W, mDNA);

                if (validDNA > 2)
                    {
                        ismutant = true;
                    }
            }

            return ismutant;
        }

        public Classes.Stats statistics(List<Classes.Mutant> list){
            Classes.Stats result = new Stats();
            functions _f = new functions();
            foreach (Classes.Mutant _m in list)
            {
                if (_f.isMutant(_m))
                    result.count_mutant_dna++;
                else
                    result.count_human_dna++;
            }

            //generate statistics
            if((result.count_mutant_dna > 0) && (list.Count > 0) ){
                result.ratio = Math.Round((double)result.count_mutant_dna/list.Count,2);

            }
            else{
                result.ratio = 0;
            }

            return result;
        }
       
    }
}