using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENETIC_TIC_TAC_TOE
{
    class Program
    {
        static int length = 9;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //Random rnd = new Random();
            int InputRnd = 0;

            double[] Input = { 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5 };
            double[,] pop = new double[10, 9];
            double[,] Inputpop = new double[10, 9];
            double[,] Inputpop2 = new double[10, 9];
            double[,] eval = new double[10, 9];
            double[] FinalEval = new double[10];
            double[] FinalEval2 = new double[10];
            double[] indexEval = new double[10];
            double[,] Mohasebe = new double[9, 4];
            double max = 0;
            int tempMu = 0;
            int posbehtarin = 0;
            int temp = 0;
            double tempMat = 0;

            int FlagWin = 0;
            //------------------------------
            for (int ei = 0; ei < 7; ei++)
            {
                for (int i = 0; i < 9; i++)
                {
                    FinalEval[i] = 0;
                }

                Console.Clear();
                Show(Input);
                Console.WriteLine("enter number from 1 to 9:");
                temp = Convert.ToInt32(Console.ReadLine());
                Input[temp - 1] = -1;
                Show(Input);
                Console.ReadLine();

                //AI
                //ساختن جمعیت اولیه
                //___________________________________
                #region pupolation
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Inputpop[i, j] = Input[j];
                    }
                }
                //parent 1
                
                for (int i = 0; i < 10; i++)
                {
                    
                    int k = 0;
                    while (k == 0)
                    {
                        InputRnd = rnd.Next(0, 9);
                        if (Inputpop[i, InputRnd] == 0.5)
                        {
                            Inputpop[i, InputRnd] = 8;
                            k = 1;
                            break;
                        }
                    }
                }
                #endregion
                
                //ارزیابی
                //_____________________________________
                //تشخیص برنده
                //fitness
                #region fitness
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        pop[i, j] = Inputpop[i, j];
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Mohasebe[k, j] = 0;
                        }
                    }

                    if (pop[i, 0] == 8)
                    {
                        Mohasebe[0, 0] = 1 + pop[i, 1] + pop[i, 2];
                        Mohasebe[0, 1] = 1 + pop[i, 4] + pop[i, 8];
                        Mohasebe[0, 2] = 1 + pop[i, 3] + pop[i, 6];
                        Mohasebe[0, 3] = 0;
                    }
                    if (pop[i, 1] == 8)
                    {
                        Mohasebe[1, 0] = pop[i, 0] + 1 + pop[i, 2];
                        Mohasebe[1, 1] = 1 + pop[i, 4] + pop[i, 7];
                        Mohasebe[1, 2] = 0;
                        Mohasebe[1, 3] = 0;
                    }
                    if (pop[i, 2] == 8)
                    {
                        Mohasebe[2, 0] = pop[i, 0] + pop[i, 1] + 1;
                        Mohasebe[2, 1] = 1 + pop[i, 5] + pop[i, 8];
                        Mohasebe[2, 2] = 1 + pop[i, 4] + pop[i, 6];
                        Mohasebe[2, 3] = 0;
                    }
                    if (pop[i, 3] == 8)
                    {
                        Mohasebe[3, 0] = pop[i, 0] + 1 + pop[i, 6];
                        Mohasebe[3, 1] = 1 + pop[i, 4] + pop[i, 5];
                        Mohasebe[3, 2] = 0;
                        Mohasebe[3, 3] = 0;
                    }
                    if (pop[i, 4] == 8)
                    {
                        Mohasebe[4, 0] = pop[i, 3] + 1 + pop[i, 5];
                        Mohasebe[4, 1] = pop[i, 1] + 1 + pop[i, 7];
                        Mohasebe[4, 2] = pop[i, 0] + 1 + pop[i, 8];
                        Mohasebe[4, 3] = pop[i, 2] + 1 + pop[i, 6];
                    }
                    if (pop[i, 5] == 8)
                    {
                        Mohasebe[5, 0] = pop[i, 2] + 1 + pop[i, 8];
                        Mohasebe[5, 1] = pop[i, 3] + pop[i, 4] + 1;
                        Mohasebe[5, 2] = 0;
                        Mohasebe[5, 3] = 0;
                    }
                    if (pop[i, 6] == 8)
                    {
                        Mohasebe[6, 0] = pop[i, 0] + pop[i, 3] + 1;
                        Mohasebe[6, 1] = pop[i, 2] + pop[i, 4] + 1;
                        Mohasebe[6, 2] = 1 + pop[i, 7] + pop[i, 8];
                        Mohasebe[6, 3] = 0;
                    }
                    if (pop[i, 7] == 8)
                    {
                        Mohasebe[7, 0] = pop[i, 6] + 1 + pop[i, 8];
                        Mohasebe[7, 1] = pop[i, 1] + pop[i, 4] + 1;
                        Mohasebe[7, 2] = 0;
                        Mohasebe[7, 3] = 0;
                    }
                    if (pop[i, 8] == 8)
                    {
                        Mohasebe[8, 0] = pop[i, 6] + pop[i, 7] + 1;
                        Mohasebe[8, 1] = pop[i, 0] + pop[i, 4] + 1;
                        Mohasebe[8, 2] = pop[i, 2] + pop[i, 5] + 1;
                        Mohasebe[8, 3] = 0;
                    }
                    for (int k = 0; k < 9; k++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (Mohasebe[k, j] == 3)
                            {
                                Mohasebe[k, j] = 823543;
                            }
                            if (Mohasebe[k, j] == -1)
                            {
                                Mohasebe[k, j] = 46656;
                            }
                            if (Mohasebe[k, j] == 2.5)
                            {
                                Mohasebe[k, j] = 3125;
                            }
                            if (Mohasebe[k, j] == 2)
                            {
                                Mohasebe[k, j] = 256;
                            }
                            if (Mohasebe[k, j] == 1)
                            {
                                Mohasebe[k, j] = 27;
                            }
                            if (Mohasebe[k, j] == 0.5)
                            {
                                Mohasebe[k, j] = 4;
                            }
                        }
                    }

                    for (int j = 0; j < 9; j++)
                    {
                        eval[i, j] = Mohasebe[j, 0] + Mohasebe[j, 1] + Mohasebe[j, 2] + Mohasebe[j, 3];
                        //Console.Write("eval[" + i.ToString() + "," + j.ToString() + "]="+eval[i,j].ToString()+" moh0: " +Mohasebe[j,0].ToString()+" moh1: "+Mohasebe[j,1].ToString()+" moh2 "+Mohasebe[j,2].ToString()+" moh3 "+Mohasebe[j,3].ToString());
                        //Console.WriteLine();
                    }

                    for (int j = 0; j < 9; j++)
                    {
                        FinalEval[i] += eval[i, j];
                        //Console.WriteLine("finaleval "+j.ToString()+":" + FinalEval[i].ToString() + "  eval i:"+i.ToString()+ ",j:"+j.ToString()+" = "+ eval[i, j].ToString());
                    }
                    //Console.ReadLine();
                }

                for (int i = 0; i < 10; i++)
                {
                    if (FinalEval[i] > max)
                    {
                        max = FinalEval[i];
                        posbehtarin = i;
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (Inputpop[i, j] == 8)
                        {
                            pop[i, j] = 1;
                    }
                        else
                        {
                        pop[i, j] = Inputpop[i, j];
                    }
                }
                }

                for (int i = 0; i < 9; i++)
                {
                    Input[i] = pop[posbehtarin, i];
                }
                #endregion

                //cheking
                #region findwinner
                Console.WriteLine();
                if ((Input[0] + Input[1] + Input[2] == 3) || (Input[0] + Input[1] + Input[2] == -3))
                {
                    FlagWin = 1;
                    if (Input[0] + Input[1] + Input[2] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[3] + Input[4] + Input[5] == 3 || Input[3] + Input[4] + Input[5] == -3)
                {
                    FlagWin = 1;
                    if (Input[3] + Input[4] + Input[5] == 3)
                    {
                        Console.WriteLine("Computer WIN");
                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[6] + Input[7] + Input[8] == 3 || Input[6] + Input[7] + Input[8] == -3)
                {
                    FlagWin = 1;
                    if (Input[6] + Input[7] + Input[8] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                //--------
                if (Input[0] + Input[3] + Input[6] == 3 || Input[0] + Input[3] + Input[6] == -3)
                {
                    FlagWin = 1;
                    if (Input[0] + Input[3] + Input[6] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[1] + Input[4] + Input[7] == 3 || Input[1] + Input[4] + Input[7] == -3)
                {
                    FlagWin = 1;
                    if (Input[1] + Input[4] + Input[7] == 3)
                    {
                        Console.WriteLine("Computer WIN");
                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[2] + Input[5] + Input[8] == 3 || Input[2] + Input[5] + Input[8] == -3)
                {
                    FlagWin = 1;
                    if (Input[2] + Input[5] + Input[8] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[2] + Input[4] + Input[6] == 3 || Input[2] + Input[4] + Input[6] == -3)
                {
                    FlagWin = 1;
                    if (Input[2] + Input[4] + Input[6] == 3)
                    {
                        Console.WriteLine("Computer WIN");
                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if ((Input[0] + Input[4] + Input[8] == 3) || (Input[0] + Input[4] + Input[8] == -3))
                {
                    FlagWin = 1;
                    if (Input[0] + Input[4] + Input[8] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }

                if (FlagWin == 1)
                {
                    Show(Input);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                //-- Environment.Exit(0);
                #endregion
               
                
                //while end 100 generation
                //_____________________________________
                for (int num = 0; num < 100; num++)
                {
                    for (int i = 5; i < 9; i++)
                    {
                        FinalEval[i] = 0;
                    }
                    //mutation
                    #region mutation
                    for (int i = 5; i < 10; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (Inputpop[i, j] == 8)
                            {
                                tempMu = j;
                                int k = 0;
                                while (k == 0)
                                {
                                    InputRnd = rnd.Next(0, 9);
                                    //Console.Write(InputRnd + " ");
                                    if (Inputpop[i, InputRnd] == 0.5)
                                    {
                                        Inputpop[i, InputRnd] = 8;
                                        Inputpop[i, tempMu] = 0.5;
                                        k = 1;
                                    }
                                }
                                if (k == 1)
                                {
                                    break;
                                }
                            }

                        }
                    }
                
                    #endregion

                    //fitness evaluate
                    #region fitnessmu
                    //tabdil baraye arzyabi
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                                pop[i, j] = Inputpop[i, j];
                        }
                    }
                    //

                    for (int i = 0; i < 10; i++)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                Mohasebe[k, j] = 0;
                            }
                        }

                        if (pop[i, 0] == 8)
                        {
                            Mohasebe[0, 0] = 1 + pop[i, 1] + pop[i, 2];
                            Mohasebe[0, 1] = 1 + pop[i, 4] + pop[i, 8];
                            Mohasebe[0, 2] = 1 + pop[i, 3] + pop[i, 6];
                            Mohasebe[0, 3] = 0;
                        }
                        if (pop[i, 1] == 8)
                        {
                            Mohasebe[1, 0] = pop[i, 0] + 1 + pop[i, 2];
                            Mohasebe[1, 1] = 1 + pop[i, 4] + pop[i, 7];
                            Mohasebe[1, 2] = 0;
                            Mohasebe[1, 3] = 0;
                        }
                        if (pop[i, 2] == 8)
                        {
                            Mohasebe[2, 0] = pop[i, 0] + pop[i, 1] + 1;
                            Mohasebe[2, 1] = 1 + pop[i, 5] + pop[i, 8];
                            Mohasebe[2, 2] = 1 + pop[i, 4] + pop[i, 6];
                            Mohasebe[2, 3] = 0;
                        }
                        if (pop[i, 3] == 8)
                        {
                            Mohasebe[3, 0] = pop[i, 0] + 1 + pop[i, 6];
                            Mohasebe[3, 1] = 1 + pop[i, 4] + pop[i, 5];
                            Mohasebe[3, 2] = 0;
                            Mohasebe[3, 3] = 0;
                        }
                        if (pop[i, 4] == 8)
                        {
                            Mohasebe[4, 0] = pop[i, 3] + 1 + pop[i, 5];
                            Mohasebe[4, 1] = pop[i, 1] + 1 + pop[i, 7];
                            Mohasebe[4, 2] = pop[i, 0] + 1 + pop[i, 8];
                            Mohasebe[4, 3] = pop[i, 2] + 1 + pop[i, 6];
                        }
                        if (pop[i, 5] == 8)
                        {
                            Mohasebe[5, 0] = pop[i, 2] + 1 + pop[i, 8];
                            Mohasebe[5, 1] = pop[i, 3] + pop[i, 4] + 1;
                            Mohasebe[5, 2] = 0;
                            Mohasebe[5, 3] = 0;
                        }
                        if (pop[i, 6] == 8)
                        {
                            Mohasebe[6, 0] = pop[i, 0] + pop[i, 3] + 1;
                            Mohasebe[6, 1] = pop[i, 2] + pop[i, 4] + 1;
                            Mohasebe[6, 2] = 1 + pop[i, 7] + pop[i, 8];
                            Mohasebe[6, 3] = 0;
                        }
                        if (pop[i, 7] == 8)
                        {
                            Mohasebe[7, 0] = pop[i, 6] + 1 + pop[i, 8];
                            Mohasebe[7, 1] = pop[i, 1] + pop[i, 4] + 1;
                            Mohasebe[7, 2] = 0;
                            Mohasebe[7, 3] = 0;
                        }
                        if (pop[i, 8] == 8)
                        {
                            Mohasebe[8, 0] = pop[i, 6] + pop[i, 7] + 1;
                            Mohasebe[8, 1] = pop[i, 0] + pop[i, 4] + 1;
                            Mohasebe[8, 2] = pop[i, 2] + pop[i, 5] + 1;
                            Mohasebe[8, 3] = 0;
                        }

                        for (int k = 0; k < 9; k++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (Mohasebe[k, j] == 3)
                                {
                                    Mohasebe[k, j] = 823543;
                                }
                                if (Mohasebe[k, j] == -1)
                                {
                                    Mohasebe[k, j] = 46656;
                                }
                                if (Mohasebe[k, j] == 2.5)
                                {
                                    Mohasebe[k, j] = 3125;
                                }
                                if (Mohasebe[k, j] == 2)
                                {
                                    Mohasebe[k, j] = 256;
                                }
                                if (Mohasebe[k, j] == 1)
                                {
                                    Mohasebe[k, j] = 27;
                                }
                                if (Mohasebe[k, j] == 0.5)
                                {
                                    Mohasebe[k, j] = 4;
                                }
                            }
                        }

                        for (int j = 0; j < 9; j++)
                        {
                            eval[i, j] = Mohasebe[j, 0] + Mohasebe[j, 1] + Mohasebe[j, 2] + Mohasebe[j, 3];
                            //Console.Write("eval[" + i.ToString() + "," + j.ToString() + "]="+eval[i,j].ToString()+" moh0: " +Mohasebe[j,0].ToString()+" moh1: "+Mohasebe[j,1].ToString()+" moh2 "+Mohasebe[j,2].ToString()+" moh3 "+Mohasebe[j,3].ToString());
                            //Console.WriteLine();
                        }

                        for (int j = 0; j < 9; j++)
                        {
                            FinalEval[i] += eval[i, j];
                            //Console.WriteLine("finaleval " + j.ToString() + ":" + FinalEval[i].ToString() + "  eval i:" + i.ToString() + ",j:" + j.ToString() + " = " + eval[i, j].ToString());
                        }
                        //Console.ReadLine();
                    }

                    //sort selection for next generation
                    #region selection for next generation

                    for (int i = 0; i < 10; i++)
                    {
                        FinalEval2[i] = FinalEval[i];
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            Inputpop2[i,j] = Inputpop[i,j];
                        }
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (FinalEval[j] < FinalEval[j + 1])
                            {
                                tempMat = FinalEval[j + 1];
                                FinalEval[j + 1] = FinalEval[j];
                                FinalEval[j] = tempMat;
                            }
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (FinalEval[i]==FinalEval2[j])
                            {
                                for (int k = 0; k < 9; k++)
                                {
                                    Inputpop[i, k] = Inputpop2[j, k];
                                }
                            }
                        }
                    }
                    #endregion sort

                    #endregion

                }

                #region findwinner

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        pop[i, j] = Inputpop[i,j];
                    }
                }
                //test barande bazi
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (pop[i, j] == 8)
                        {
                            pop[i, j] = 1;
                        }
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (FinalEval[i] > max)
                    {
                        max = FinalEval[i];
                        posbehtarin = i;
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    Input[i] = pop[posbehtarin, i];
                }
                

                Console.WriteLine();
                if ((Input[0] + Input[1] + Input[2] == 3) || (Input[0] + Input[1] + Input[2] == -3))
                {
                    FlagWin = 1;
                    if (Input[0] + Input[1] + Input[2] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[3] + Input[4] + Input[5] == 3 || Input[3] + Input[4] + Input[5] == -3)
                {
                    FlagWin = 1;
                    if (Input[3] + Input[4] + Input[5] == 3)
                    {
                        Console.WriteLine("Computer WIN");
                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[6] + Input[7] + Input[8] == 3 || Input[6] + Input[7] + Input[8] == -3)
                {
                    FlagWin = 1;
                    if (Input[6] + Input[7] + Input[8] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                //--------
                if (Input[0] + Input[3] + Input[6] == 3 || Input[0] + Input[3] + Input[6] == -3)
                {
                    FlagWin = 1;
                    if (Input[0] + Input[3] + Input[6] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[1] + Input[4] + Input[7] == 3 || Input[1] + Input[4] + Input[7] == -3)
                {
                    FlagWin = 1;
                    if (Input[1] + Input[4] + Input[7] == 3)
                    {
                        Console.WriteLine("Computer WIN");
                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[2] + Input[5] + Input[8] == 3 || Input[2] + Input[5] + Input[8] == -3)
                {
                    FlagWin = 1;
                    if (Input[2] + Input[5] + Input[8] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if (Input[2] + Input[4] + Input[6] == 3 || Input[2] + Input[4] + Input[6] == -3)
                {
                    FlagWin = 1;
                    if (Input[2] + Input[4] + Input[6] == 3)
                    {
                        Console.WriteLine("Computer WIN");
                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                //--------
                if ((Input[0] + Input[4] + Input[8] == 3) || (Input[0] + Input[4] + Input[8] == -3))
                {
                    FlagWin = 1;
                    if (Input[0] + Input[4] + Input[8] == 3)
                    {
                        Console.WriteLine("Computer WIN");

                    }
                    else
                    {
                        Console.WriteLine("Player WIN");
                    }
                }
                

                if (FlagWin == 1)
                {
                    Show(Input);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                //-- Environment.Exit(0);
                #endregion
            
            }


        }
        static void Show(double[] Input)
        {
            Console.WriteLine("_________              _________");
            for (int i = 0; i < length; i++)
            {
                if (Input[i] == 0.5)
                {
                    Console.Write(" - ");
                }
                if (Input[i] == 1)
                {
                    Console.Write(" X ");
                }
                if (Input[i] == -1)
                {
                    Console.Write(" O ");
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.Write("               " + (i - 1).ToString() + "  " + i.ToString() + "  " + (i + 1).ToString() + "  ");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("_________              _________");
            Console.WriteLine();
        }

        static void Show1(double[] Input,double[] finaleval)
        {
            Console.WriteLine("_________              _________");
            for (int i = 0; i < length; i++)
            {
                if (Input[i] == 0.5)
                {
                    Console.Write(" "+Input[i].ToString()+" ");
                }
                if (Input[i] == 1)
                {
                    Console.Write(" " + Input[i].ToString() + " ");
                }
                if (Input[i] == -1)
                {
                    Console.Write(" " + Input[i].ToString() + " ");
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.Write("               " + (finaleval[i - 1]).ToString() + "  " + finaleval[i].ToString() + "  " + finaleval[i + 1].ToString() + "  ");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("_________              _________");
            Console.WriteLine();
        }
    }
}
