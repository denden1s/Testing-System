using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using testing_system.Classes.ForDataBase;

namespace testing_system.Classes
{
    static class SystemFunctions
    {
        /// <summary>
        /// Необходим для сортировки пользователей
        /// </summary>
        /// <param name="_usersList">Список пользователей</param>
        private static void Sort(List<User> _usersList)
        {
            _usersList.Sort(delegate (User firstUser, User secondUser)
            { return firstUser.Name.CompareTo(secondUser.Name); });
        }

        /// <summary>
        /// Необходим для сортировки тем из ТБ
        /// </summary>
        /// <param name="_mathList">Список тем из ТБ</param>
        private static void Sort(List<InformationAboutMath> _mathList)
        {
            _mathList.Sort(delegate (InformationAboutMath firstTheme, InformationAboutMath secondTheme)
            { return firstTheme.Name.CompareTo(secondTheme.Name); });
        }

        /// <summary>
        /// Необходим для сортировки тестов
        /// </summary>
        /// <param name="_testsList">Список тестов</param>
        private static void Sort(List<TestName> _testsList)
        {
            _testsList.Sort(delegate (TestName firstTest, TestName secondTest)
            { return firstTest.Name.CompareTo(secondTest.Name); });
        }

        /// <summary>
        /// Необходим для передачи списка пользователей на отображение
        /// </summary>
        /// <param name="_usersList">Список пользователей</param>
        public static void GetList(List<User> _usersList)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if ((db.Users.Count() != 0) && (_usersList.Count == 0))
                    {
                        foreach (User u in db.Users)
                        {
                            _usersList.Add(new User(u.Id, u.Name, u.Password, u.IsAuthorized, u.UserStatus));
                        }
                    }

                    if (_usersList.Count > 0)
                    {
                        Sort(_usersList);
                    }
                }
                GC.Collect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для заполнения списка информации из ТБ и его отображения
        /// </summary>
        /// <param name="_mathInfoList">Список тем из ТБ</param>
        public static void GetList(List<InformationAboutMath> _mathInfoList)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if ((db.informationAboutMaths.Count() != 0) && (_mathInfoList.Count == 0))
                    {
                        foreach (InformationAboutMath i in db.informationAboutMaths)
                        {
                            _mathInfoList.Add(new InformationAboutMath(i.ThemeID, i.Name, i.ThemeContent));
                        }
                    }
                    if (_mathInfoList.Count > 0)
                    {
                        Sort(_mathInfoList);
                    }
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для заполнения списка тестов и его отображения
        /// </summary>
        /// <param name="_testsList">Список тестов</param>
        public static void GetList(List<TestName> _testsList)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if ((db.testNames.Count() != 0) && (_testsList.Count == 0))
                    {
                        foreach (TestName i in db.testNames)
                        {
                            _testsList.Add(new TestName(i.Name, i.TestID));
                        }
                    }
                    if (_testsList.Count > 0)
                    {
                        Sort(_testsList);

                    }
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для отображения списка вопросов из теста
        /// </summary>
        /// <param name="_questionsList">Список вопросов</param>
        /// <param name="_testName">Наименование теста</param>
        /// <param name="_qNamesList">Список наименований вопросов</param>
        public static void GetList(List<QuestionAndAnswer> _questionsList, string _testName, List<QuestionName> _qNamesList)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    //выборка определенного теста
                    var testName = db.testNames.Where(i => i.Name == _testName);

                    //выборка вопросов из теста
                    var questions = from b in db.questionAndAnswers
                                    where b.TestID == testName.Single().TestID
                                    select b;
                    _questionsList.Clear();
                    _qNamesList.Clear();
                    foreach (var q in questions)
                    {
                        _questionsList.Add(q);

                    }
                    foreach (QuestionAndAnswer q in _questionsList)
                    {
                        var qName = db.questionNames.Find(q.QuestionID, q.TestID);
                        QuestionName questionName = new QuestionName();
                        questionName = (QuestionName)qName;
                        _qNamesList.Add(qName);
                    }
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }   
        }

        /// <summary>
        /// необходим для отображения вопросов и его ответов
        /// </summary>
        /// <param name="_qNamesList">Список наименований вопрос</param>
        /// <param name="_q1">Первый ответ (верный)</param>
        /// <param name="_q2">Второй ответ</param>
        /// <param name="_q3">Третий ответ</param>
        /// <param name="_q4">Четвертый ответ</param>
        /// <param name="_selectedId">Идентификатор выбранного элемента в списке</param>
        public static void Show(List<QuestionName> _qNamesList, TextBox _q1,
            TextBox _q2, TextBox _q3, TextBox _q4, int _selectedId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var question = db.questionAndAnswers.Find(_qNamesList[_selectedId].TestID,
                        _qNamesList[_selectedId].QuestionID);
                    _q1.Text = question.RightAnswer;
                    _q2.Text = question.WrongAnswer_1;
                    _q3.Text = question.WrongAnswer_2;
                    _q4.Text = question.WrongAnswer_3;
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для очистки текстовых полей
        /// </summary>
        /// <param name="_textBox">Строка, которую необходимо очистить</param>
        public static void ClearTextBox(params TextBox[] _textBox)
        {
            for (int i = 0; i < _textBox.Count(); i++)
                _textBox[i].Clear();
        }

        /// <summary>
        /// Необходим для добавления пользователя во все необходимые
        /// списки и их отображения 
        /// </summary>
        /// <param name="_usersList">Список пользователей</param>
        /// <param name="_nameFromTextBox">Введённое имя</param>
        /// <param name="_passwordFromTextBox">Введённый пароль</param>
        public static void Add(List<User> _usersList,TextBox _nameFromTextBox,
            TextBox _passwordFromTextBox)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    bool findUser = db.Users.Any(u => u.Name == _nameFromTextBox.Text);
                    if (findUser == false)
                    {
                        if ((_nameFromTextBox.TextLength > 2) && (_passwordFromTextBox.TextLength > 0))
                        {
                            User user = new User(_nameFromTextBox.Text, _passwordFromTextBox.Text, "пользователь");
                            db.Users.Add(user);
                            db.SaveChanges();
                            _usersList.Add(user);
                            Sort(_usersList);
                            MessageBox.Show("Пользователь добавлен");
                            ClearTextBox(_nameFromTextBox, _passwordFromTextBox);
                        }
                        else
                            MessageBox.Show("Информация пользователя не соответствует требованиям");
                    }
                    else
                        MessageBox.Show("Имя занято");
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для добавления информации в ТБ и ее отображения
        /// </summary>
        /// <param name="_mathInfoList">Список имеющейся информации из ТБ</param>
        /// <param name="_themeNameFromTextBox">Введенное имя темы</param>
        /// <param name="_content">Наполнение темы контентом</param>
        public static void Add(List<InformationAboutMath> _mathInfoList, TextBox _themeNameFromTextBox,
            string _content)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    bool findTheme = db.informationAboutMaths.Any(i => i.Name == _themeNameFromTextBox.Text);
                    if (!findTheme)
                    {
                        if ((_themeNameFromTextBox.TextLength > 6) && (_content.Length > 20))
                        {
                            InformationAboutMath math = new InformationAboutMath(_themeNameFromTextBox.Text,
                                _content);
                            db.informationAboutMaths.Add(math);
                            db.SaveChanges();
                            _mathInfoList.Add(math);
                            SystemFunctions.GetList(_mathInfoList);
                            ClearTextBox(_themeNameFromTextBox);
                            _content = "";
                            MessageBox.Show("Информация успешно добавлена.");
                        }
                        else
                            MessageBox.Show("Тема не соответствует требованиям");
                    }
                    else
                        MessageBox.Show("Имя занято");
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для добавления теста 
        /// </summary>
        /// <param name="_testNamesList">Список имеющихся тестов</param>
        /// <param name="_questionsList">Список имеющихся вопросов и ответов</param>
        /// <param name="_enteredName">Введенное наименование теста</param>
        /// <param name="_questionName">Введенные наименования вопросов</param>       
        /// <param name="_questions">Заполненные вопросы и ответы на них</param>
        public static void Add(List<TestName> _testNamesList, List<QuestionAndAnswer> _questionsList,
            string _enteredName, string[] _questionName, string[,] _questions)
        {
            int id = 0;
            try
            {
                bool except = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = i + 1; j < 9; j++)
                    {
                        if (_questionName[i] == _questionName[j])
                        {
                            except = true;
                            break;
                        }
                    }
                }
                if(!except)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        bool findTest = db.testNames.Any(i => i.Name == _enteredName);
                        if (!findTest)
                        {

                            db.testNames.Add(new TestName(_enteredName));
                            _testNamesList.Add(new TestName(_enteredName));
                            db.SaveChanges();
                            var testId = from b in db.testNames
                                            where b.Name == _enteredName
                                            select b;
                            if ((testId != null) && (db.testNames.Count() > 0))
                                id = testId.Single().TestID;
                            else
                                id = 0;
                                
                            for (int i = 0; i < 10; i++)
                            {
                                QuestionAndAnswer question = new QuestionAndAnswer(id, i, _questions[i, 0],
                                    _questions[i, 1], _questions[i, 2], _questions[i, 3]);
                                db.questionNames.Add(new QuestionName(id, i, _questionName[i]));
                                _questionsList.Add(question);
                                db.questionAndAnswers.Add(question);
                            }
                            db.SaveChanges();
                            MessageBox.Show("Тест успешно добавлен");
                        }
                        else
                            MessageBox.Show("Имя занято");                            
                    }
                }
                else
                    MessageBox.Show("В тесте присутствуют повторяющиеся вопросы", "Тест не добавлен");
                
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для обавление вопроса к тесту
        /// </summary>
        /// <param name="_questionsList">Список вопросов и ответов</param>
        /// <param name="_qName">Наименование вопроса</param>
        /// <param name="_testId">Уникальный идентификатор теста</param>
        /// <param name="_questionId">Уникальный идентификатор вопроса</param>
        /// <param name="_answers">Ответы на вопрос</param>
        public static void Add(List<QuestionAndAnswer> _questionsList,
            string _qName,int _testId, int _questionId, string[] _answers)
        {
            try
            {
                int newQuestionId = _questionId + 1;
                using (ApplicationContext db = new ApplicationContext())
                {
                    var findQName = db.questionNames.FirstOrDefault(i => i.Name == _qName && i.TestID == _testId);
                    if (findQName == null)
                    {
                        QuestionAndAnswer nQuestion = new QuestionAndAnswer(_testId, newQuestionId, _answers[0],
                            _answers[1], _answers[2], _answers[3]);
                        _questionsList.Add(nQuestion);
                        db.questionAndAnswers.Add(nQuestion);
                        db.questionNames.Add(new QuestionName(_testId, newQuestionId, _qName));
                        db.SaveChanges();
                        MessageBox.Show("Вопрос добавлен");
                    }
                    else
                        MessageBox.Show("Данный вопрос уже существует");                    
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для сохранения статистики прохождения теста
        /// </summary>
        /// <param name="_info">вся информация о статистике</param>
        public static void SaveUserStatistic(params int[] _info)
        {
            try
            {
                StatisticOfTest statistic = new StatisticOfTest(_info[0], _info[1], _info[2], _info[3]);
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.statisticOfTests.Add(statistic);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Необходим для удаления пользователя из системы
        /// </summary>
        /// <param name="_usersList">Список имеющихся пользователей</param>
        /// <param name="_listBoxId">Уникальный идентификатор выбранного пользователя</param>
        public static void Remove(List<User> _usersList, int _listBoxId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (_usersList[_listBoxId].IsAuthorized == false)
                    {
                        DialogResult userResult = MessageBox.Show($"Вы действительно хотите удалить " +
                            $"пользователя {_usersList[_listBoxId].Name}",
                            "Удаление пользователя!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button2,
                            MessageBoxOptions.DefaultDesktopOnly);
                        if (userResult == DialogResult.Yes)
                        {
                            int removeUserID = _usersList[_listBoxId].Id;
                            var item = db.Users.Find(removeUserID);
                            if (item != null)
                            {
                                db.Users.Remove(item);
                                _usersList.Remove(_usersList[_listBoxId]);
                                db.SaveChanges();
                            }
                        }
                        MessageBox.Show("Пользователь удален");
                    }
                    else
                        MessageBox.Show("Невозможно удалить администратора");
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }            
        }

        /// <summary>
        /// Необходим для удаления  информации из ТБ
        /// </summary>
        /// <param name="_MathInfoList">Список математических тем</param>
        /// <param name="_listBoxId">Уникальный идентификатор выбранной темы</param>
        public static void Remove(List<InformationAboutMath> _MathInfoList, int _listBoxId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    DialogResult themeResult = MessageBox.Show($"Вы действительно хотите удалить " +
                            $"тему {_MathInfoList[_listBoxId].Name}",
                            "Удаление темы!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button2,
                            MessageBoxOptions.DefaultDesktopOnly);
                    if (themeResult == DialogResult.Yes)
                    {
                        int removeThemeID = _MathInfoList[_listBoxId].ThemeID;
                        var item = db.informationAboutMaths.Find(removeThemeID);
                        if (item != null)
                        {
                            db.informationAboutMaths.Remove(item);
                            _MathInfoList.Remove(_MathInfoList[_listBoxId]);
                            db.SaveChanges();
                            MessageBox.Show("Информация удалена");
                        }
                    }
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для удаления вопросов из теста
        /// </summary>
        /// <param name="_questionsList">Список вопросов из теста</param>
        /// <param name="_listBoxId">Уникальный идентификатор выбранного вопроса</param>
        public static void Remove(List<QuestionAndAnswer> _questionsList, int _listBoxId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var question = db.questionNames.Find(_questionsList[_listBoxId].QuestionID,
                        _questionsList[_listBoxId].TestID);
                    DialogResult questionResult = MessageBox.Show($"Вы действительно хотите удалить " +
                            $"вопрос {question.Name}",
                                    "Удаление вопроса!",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button2,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    if (questionResult == DialogResult.Yes)
                    {
                        int removeQuestionID = _questionsList[_listBoxId].QuestionID;
                        int removeTestID = _questionsList[_listBoxId].TestID;
                        var item = db.questionNames.Find(removeQuestionID, removeTestID);
                        var secItem = db.questionAndAnswers.Find(removeTestID, removeQuestionID);
                        if (item != null)
                        {
                            db.questionAndAnswers.Remove(secItem);
                            db.questionNames.Remove(item);
                            db.SaveChanges();
                            _questionsList.Remove(_questionsList[_listBoxId]);                                
                            MessageBox.Show("Информация удалена");
                        }
                    }
                }

                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для удаления теста
        /// </summary>
        /// <param name="_testNamesList">Список наименований теста</param>
        /// <param name="_listBoxId">Идентификатор выбранного теста в ListBox-е</param>
        public static void Remove(List<TestName> _testNamesList, int _listBoxId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var findTestName = db.testNames.First(i => i.Name == _testNamesList[_listBoxId].Name);
                    DialogResult questionResult = MessageBox.Show($"Вы действительно хотите удалить " +
                            $"тест {findTestName.Name}",
                                    "Удаление вопроса!",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button2,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    if (questionResult == DialogResult.Yes)
                    {
                        if (findTestName != null)
                        {
                            db.testNames.Remove(findTestName);
                            db.SaveChanges();
                            _testNamesList.Remove(findTestName);
                            MessageBox.Show("Тест удален");
                        }
                        else
                            MessageBox.Show("Тест не найден");
                    }
                }
                GC.Collect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для изменения информации из ТБ
        /// </summary>
        /// <param name="_mathInfoList">Список информации из ТБ</param>
        /// <param name="_themeNameFromTextBox">Наименование выбранной темы</param>
        /// <param name="_themeContent">Содержимое темы в виде rtf документа</param>
        /// <param name="_listBoxId">Уникальный идентификатор выбранной темы</param>
        public static void Edit(List<InformationAboutMath> _mathInfoList,
            TextBox _themeNameFromTextBox, RichTextBox _themeContent, int _listBoxId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if ((_themeNameFromTextBox.TextLength > 6) && (_themeContent.TextLength > 20))
                    {
                    bool findName = db.informationAboutMaths.Any(i => i.Name == _themeNameFromTextBox.Text);
                        int updateID = _mathInfoList[_listBoxId].ThemeID;
                        var itemForUpdate = db.informationAboutMaths.Find(updateID);
                        if (itemForUpdate != null)
                        {
                            itemForUpdate.Name = _themeNameFromTextBox.Text;
                            _mathInfoList[_listBoxId].Name = _themeNameFromTextBox.Text;
                            if ((!_mathInfoList[_listBoxId].ThemeContent.Contains(".rtf")))
                                _mathInfoList[_listBoxId].ThemeContent = _themeContent.Text;
                            else
                                _themeContent.SaveFile(_mathInfoList[_listBoxId].ThemeContent);

                            db.informationAboutMaths.Update(itemForUpdate);
                            db.SaveChanges();
                            Sort(_mathInfoList);
                            GetList(_mathInfoList);
                            ClearTextBox(_themeNameFromTextBox);
                            _themeContent.Text = "";
                        }
                        MessageBox.Show("Информация изменена");
                    }
                    else
                        MessageBox.Show("Некорректный ввод данных");
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для изменения вопросов в тесте
        /// </summary>
        /// <param name="_questionsList">Список вопросов</param>
        /// <param name="_selectedQuestionId">Индекс выбранного вопроса в ListBox-e</param>
        /// <param name="_answersAndName">Наименования вопроса и ответы</param>
        public static void Edit(List<QuestionAndAnswer> _questionsList,
            int _selectedQuestionId, params string[] _answersAndName )
        {
            try
            {
                bool isChanged = false;
                using(ApplicationContext db = new ApplicationContext())
                {
                    int updateQuestionID = _questionsList[_selectedQuestionId].QuestionID;
                    int updateTestID = _questionsList[_selectedQuestionId].TestID;
                    var itemForUpdate = db.questionAndAnswers.Find(updateTestID, updateQuestionID);
                    string testName = db.testNames.Find(updateTestID).Name;
                    
                    if(itemForUpdate != null)
                    {
                        var questionNameItem = db.questionNames.Find(updateQuestionID, updateTestID);
                        string questionName = questionNameItem.Name;
                        string[] answersAndName = { itemForUpdate.RightAnswer, itemForUpdate.WrongAnswer_1,
                        itemForUpdate.WrongAnswer_2, itemForUpdate.WrongAnswer_3, questionName};
                        for (int i = 0; i < _answersAndName.Length; i++)
                        {
                            if(_answersAndName[i].Length == 0)
                            {
                                isChanged = false;
                                break;
                            }
                            else
                            {
                                if (answersAndName[i] != _answersAndName[i])
                                {
                                    isChanged = true;
                                    break;
                                }
                            } 
                        }
                        if (isChanged)
                        {
                            questionNameItem.Name = _answersAndName[4];
                            itemForUpdate.RightAnswer = _answersAndName[0];
                            itemForUpdate.WrongAnswer_1 = _answersAndName[1];
                            itemForUpdate.WrongAnswer_2 = _answersAndName[2];
                            itemForUpdate.WrongAnswer_3 = _answersAndName[3];
                            db.questionNames.Update(questionNameItem);
                            db.questionAndAnswers.Update(itemForUpdate);
                            db.SaveChanges();       
                            MessageBox.Show("Информация обновлена");                           
                        }
                        else
                            MessageBox.Show("Необходимо указать изменения!");
                    }
                }
                GC.Collect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
        }

        /// <summary>
        /// Необходим для подготовки вопросов к тесту
        /// </summary>
        /// <param name="_testId">Уникальный идентификатор теста</param>
        /// <returns></returns>
        public static List<QuestionName> PrepareQuestions(int _testId)
        {
            List<QuestionName> listForTest = new List<QuestionName>();
            using (ApplicationContext db = new ApplicationContext())
            {
                var _questionsNameList = db.questionNames.Where(i => i.TestID == _testId).ToList();
                MixQuestionsOrAnswers(_questionsNameList);
                listForTest = _questionsNameList;
            }
            return listForTest;
        }

        /// <summary>
        /// Необходим для перемешивания ответов вопроса
        /// </summary>
        /// <param name="_answers">Список ответов на вопросы</param>
        /// <param name="_questionPos">Позиция вопроса в списке вопросов</param>
        public static void MixAnswers(ref string[,] _answers, int _questionPos)
        {
            List<string> answers = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                answers.Add(_answers[_questionPos,i]);
            }
            MixQuestionsOrAnswers(answers);
            for (int i = 0; i < 4; i++)
            {
                _answers[_questionPos, i] = answers[i];
            }
        }

        /// <summary>
        /// Тасование Фишера-Йетса
        /// </summary>
        /// <param name="_mixedArray">Перемешанное множество элементов</param>
        public static void MixQuestionsOrAnswers<T>(List<T> _mixedArray)
        {
            //Тасование Фишера-Йетса
            Random rand = new Random();
            for(int i = _mixedArray.Count; i > 0; i--)
    {
                int j = rand.Next(i - 1);

                var tmp = _mixedArray[j];
                _mixedArray[j] = _mixedArray[i - 1];
                _mixedArray[i - 1] = tmp;
            }
        }

        /// <summary>
        /// Необходим для представления статистики теста пользователю
        /// </summary>
        /// <param name="_user">Конкретный пользователь</param>
        /// <returns>Статистика пользователя в текстовом виде</returns>
        public static string ViewStatisticOfTests(User _user)
        {
            string result = "";
            try
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    var statistic = (from b in db.statisticOfTests
                                     where b.UserID == _user.Id
                                     select b).ToList();

                    if (statistic.Count() > 0)
                    {
                        string[] testsNames = new string[statistic.Count()];
                        for (int i = 0; i < statistic.Count(); i++)
                        {
                            var testName = db.testNames.Find(statistic[i].TestID);
                            testsNames[i] = testName.Name;
                            result += $"При прохождении теста \"{testsNames[i]}\" правильно были отвечены: " +
                                $"{statistic[i].Mark} из 10 вопросов. \n";
                        }
                    }
                    else
                        result = "Статистика отсутствует";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникла ошибка!");
            }
            return result;
        }
    }
}