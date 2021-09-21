using System;
using System.Collections;
using System.IO;

namespace ebi
{
    class BFProgram
    {
        //Code Vars
        readonly string code;
        int code_pos;

        //memory info
        uint[] mem;
        uint mem_loc;

        //Loop info, for nested loops
        ArrayList loop_pos;
        int loop_amt = -1;

        BFProgram() 
        {
            code = "+[,>++[<----->-]<]"; //exits on ESC
            mem = new uint[16]; //change array size to change memory size
            loop_pos = new ArrayList();
        }

        BFProgram(string file_name)
        {
            code = File.ReadAllText(file_name);
            Console.WriteLine(code);
            mem = new uint[16];
            loop_pos = new ArrayList();
        }

        public int ExecCode()
        {
            char c_char = code[0];
            while(true)
            {
                switch (c_char)
                {
                    //Cell operations
                    //inc cell, dec cell, inc cellptr, dec cellptr
                    case '+':
                        mem[mem_loc]++;
                        break;
                    case '-':
                        mem[mem_loc]--;
                        break;
                    case '>':
                        mem_loc++;
                        break;
                    case '<':
                        mem_loc--;
                        break;

                    //IO ops, print and get
                    case '.':
                        Console.Write((char)mem[mem_loc]);
                        break;
                    case ',':
                        mem[mem_loc] = Console.ReadKey().KeyChar;
                        break;

                    //Looping
                    case '[':
                        //if cell isnt 0
                        if (mem[mem_loc] != 0)
                        {
                            loop_amt++;
                            loop_pos.Add(code_pos);
                        } //if it is skip to the matching ]
                        else
                        {
                            //advance code postition
                            char c = code[++code_pos];
                            int nested = 0; //amount of nested loops
                            while (true)
                            {
                                if (c == '[')
                                {
                                    nested++;
                                }
                                else if (c == ']')
                                {
                                    if (nested == 0) break;
                                    nested--;
                                }
                                c = code[++code_pos];
                            }
                        }
                        break;
                    case ']':
                        //if its 0 loop else continue
                        if (mem[mem_loc] != 0)
                        {
                            code_pos = (int)loop_pos[loop_amt];
                        }
                        else
                        {
                            loop_amt--;

                        }
                        break;
                }

                //advance code pos
                code_pos++;

                //if EOF then stop looping
                if (code_pos == code.Length) {
                    break;
                }
                c_char = code[code_pos];
            }

            return 0;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Eris's Brainfuck Interpreter");
            BFProgram b;

            //if theres args then load that file
            if (args.Length != 1)
            {
                b = new BFProgram();
            } 
            else
            {
                b = new BFProgram(args[0]);
            }

            b.ExecCode();
        }
    }
}
