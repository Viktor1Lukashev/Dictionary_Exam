using exam.UserExeption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.WorkWithDictionary
{
    class GeneralWorking
    {
        public static void WorkWithDict(Idict MyDict)
        {
            int answer;
            do
            {

                Console.WriteLine("1) добавить слово и его перевод");
                Console.WriteLine("2) удалить слово и все его переводы");
                Console.WriteLine("3) удалить только перевод определенного слова");
                Console.WriteLine("4) изменить слово");
                Console.WriteLine("5) изменить перевод в слове");
                Console.WriteLine("6) экспортировать слово с его переводом в новый файл");
                Console.WriteLine("7) закрыть словарь и вернуться в предыдущее меню");
                Console.WriteLine("8) сохранить данные в словаре");
               
                bool CheckAnswer =  Int32.TryParse(Console.ReadLine(), out answer);
                try
                {
                    if (answer > 9 || answer < 0 || !CheckAnswer)
                    {
                        throw new AnswerExeption("ваше значение некорректно! оно должно быть в промежутке от 1 до 7");
                    }
                }
                catch (AnswerExeption ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

                switch (answer)
                {

                    case 1:

                        Console.WriteLine("Введите слово:");
                        string word = Console.ReadLine();
                        Console.WriteLine("Введите перевод слова:");
                        string translate = Console.ReadLine();
                        try
                        {
                            MyDict.AddToDictionary(word, translate);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }

                        break;

                    case 2:
                        Console.WriteLine("Введите слово которое хотите удалить:");
                        string deleteword = Console.ReadLine();
                        MyDict.DelWord(deleteword);
                        MyDict.SaveInFile();
                        break;
                    case 3:
                        Console.WriteLine("Введите слово у которого хотите удалить перевод:");
                        string deletedword = Console.ReadLine();
                        Console.WriteLine("введите перевод слова для удаления:");
                        string deletetranslate = Console.ReadLine();
                        try
                        {
                            MyDict.DelTranslate(deletedword, deletetranslate);
                            MyDict.SaveInFile();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        break; 
                        case 4:
                        
                        Console.WriteLine("Введите слово которое хотите заменить:");
                        string ChangeWord = Console.ReadLine();
                        try
                        {
                            MyDict.ChangeWord(ChangeWord);
                            //    Console.WriteLine("Введите слово у которого хотите удалить перевод:");
                            //    string deletedword = Console.ReadLine();
                            //    Console.WriteLine("введите перевод слова для удаления:");
                            //    string deletetranslate = Console.ReadLine();
                            //    m1.Delete(deletedword, deletetranslate);
                            break;
                        }
                        catch (ContainsElemExeption ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        catch(ErrorCharExeption ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                    case 5:

                        Console.WriteLine("Введите слово, перевод которого хотите заменить:");
                        string ChangeWr = Console.ReadLine();
                        Console.WriteLine($"Введите перевод слова {ChangeWr}, которы хотите заменить:");
                        string ChangeTr = Console.ReadLine();
                        Console.WriteLine($"введите новое значение слова для слова {ChangeWr} ");
                        string NewTr = Console.ReadLine();

                        try
                        {
                            MyDict.ChangeTranslate(ChangeWr,ChangeTr, NewTr);
                            //    Console.WriteLine("Введите слово у которого хотите удалить перевод:");
                            //    string deletedword = Console.ReadLine();
                            //    Console.WriteLine("введите перевод слова для удаления:");
                            //    string deletetranslate = Console.ReadLine();
                            //    m1.Delete(deletedword, deletetranslate);
                            break;
                        }
                        catch (ContainsElemExeption ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }

                    case 6:

                        Console.WriteLine("Введите слово, перевод которого хотите экспортировать:");
                        string UserWord = Console.ReadLine();
                        Console.WriteLine($"Введите наименование для нового файла:");
                        string FileWordName = Console.ReadLine();
                       

                        try
                        {
                            MyDict.ExportWord(UserWord, FileWordName);
                            //    Console.WriteLine("Введите слово у которого хотите удалить перевод:");
                            //    string deletedword = Console.ReadLine();
                            //    Console.WriteLine("введите перевод слова для удаления:");
                            //    string deletetranslate = Console.ReadLine();
                            //    m1.Delete(deletedword, deletetranslate);
                            break;
                        }
                        catch (ContainsElemExeption ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                    case 7:
                        string SaveAnswer;
                        do
                        {
                            Console.WriteLine("сохранить данные перед выходом?");
                            SaveAnswer = Console.ReadLine();
                            SaveAnswer.ToLower();
                        } while (SaveAnswer != "y" && SaveAnswer != "n");
                        if(SaveAnswer == "y")
                        {
                            MyDict.SaveInFile();
                        }
                        answer = 8;
                        
                        break;
                    case 8:

                        MyDict.SaveInFile();
                        Console.WriteLine("все изменения успешно сохранены!");
                        break;

                }
                //Console.WriteLine("хотите уверены, что хоитите закончить работу с данным словарем? Все несохраненные данные будут утеряны!");
                //Int32.TryParse(Console.ReadLine(), out answer);
                
            } while (answer != 8);
           // MyDict.SaveNew();
        }
    }
}
