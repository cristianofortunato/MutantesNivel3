using System;
using Xunit;
using Mutantes;
using System.Collections.Generic;

namespace Mutantes.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("A")]
        public void isInputValid(char s)
        {
            functions _f = new functions();
            bool ValidInput = _f.InputValid(s);
            Assert.Equal(true, ValidInput);
        }


        [Theory]
        [InlineData("AAAAAAA")]
        [InlineData("AAAAAAAC")]
        [InlineData("AAAATGAC")]
        public void isDNASequenceValid(string DNA)
        {
            bool ValidInput = true;
            functions _f = new functions();
            char[] sequenceDNA = DNA.ToCharArray();
            foreach (char c in sequenceDNA)
            {
                ValidInput = _f.InputValid(c);
                if (!ValidInput)
                    break;
                
            }
            Assert.Equal(true, ValidInput);
        }

        [Theory]
        [InlineData("B")]
        [InlineData("AAAATXAB")]
        public void isDNASequenceInvalid(string DNA)
        {
            bool ValidInput = true;
            functions _f = new functions();
            char[] sequenceDNA = DNA.ToCharArray();
            foreach (char c in sequenceDNA)
            {
                ValidInput = _f.InputValid(c);
                if (!ValidInput)
                    break;
            }
            Assert.Equal(false, ValidInput);
        }


        [Theory]
        [InlineData(true)]
        public void isMutateDNA(bool expected)
        {

            Classes.Mutant _person = new Classes.Mutant();
            _person.DNA = new string[]{"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"};
            bool isMutante = false;
            functions _f = new functions();
            isMutante = _f.isMutant(_person);
            Assert.Equal(expected, isMutante);
        }

        [Theory]
        [InlineData(false)]
        public void isMutateDNALess(bool expected)
        {

            Classes.Mutant _person = new Classes.Mutant();
            _person.DNA = new string[] { "A", "C", "T", "A", "C", "T" };
            bool isMutante = false;
            functions _f = new functions();
            isMutante = _f.isMutant(_person);
            Assert.Equal(expected, isMutante);
        }

        [Theory]
        [InlineData(false)]
        public void isNotMutateDNA(bool expected)
        {

            Classes.Mutant _person = new Classes.Mutant();
            _person.DNA = new string[] {"ATGCGA","CAGTGC","TTATTT","AGACGG","GCGTCA","TCACTG"};
            bool isMutante = false;
            functions _f = new functions();
            isMutante = _f.isMutant(_person);
            Assert.Equal(expected, isMutante);
        }




    }
}
