// Russian syntactic analyzer demo
// http://www.solarix.ru/for_developers/docs/syntax_analyzer.shtml
//
// CD->19.02.2009
// LC->06.03.2012

using System;
using System.Text;
using System.IO;
using SolarixGrammarEngineNET;


namespace synan
{
class Program
{
 static void PrintNode( IntPtr hNode )
 {
  Int32 n_leaf = GrammarEngine.sol_CountLeafs(hNode);
  StringBuilder sb = new StringBuilder();
  GrammarEngine.sol_GetNodeContents(hNode, sb);
  Console.Write(sb.ToString());

  if( n_leaf>0 )
   {
    Console.Write( "( " );

    for( int ileaf=0; ileaf<n_leaf; ++ileaf )
     {
      IntPtr hLeaf = GrammarEngine.sol_GetLeaf( hNode, ileaf );
      PrintNode(hLeaf);
      Console.Write( " " ); 
     }

    Console.Write( ")" );
   }

  return;
 }



 static void Main(string[] args)
 {
  // http://www.solarix.ru/api/ru/sol_CreateGrammarEngine.shtml
  IntPtr hEngine = GrammarEngine.sol_CreateGrammarEngineW(@"..\..\..\..\..\..\..\bin-windows\dictionary.xml");
  if( hEngine==(IntPtr)null )
   {
    Console.WriteLine( "Could not load the dictionary" );
    return;
   }

  Int32 r = GrammarEngine.sol_DictionaryVersion(hEngine);
  if (r != -1)
   {
    Console.WriteLine("Словарь загружен. Версия: " + r.ToString());
   }
  else
   {
    Console.WriteLine("Ошибка загрузки словаря.");
    return;
   }


/*
  IntPtr hSegmenter = GrammarEngine.sol_CreateSentenceBrokerMemW( hEngine, "Greenspan's fraud: how two decades of his policies have undermined the global economy. A delegate will often have a void return type.", -1 );
  int rc1 = GrammarEngine.sol_FetchSentence(hSegmenter);
  string sentence1 = GrammarEngine.sol_GetFetchedSentenceFX( hSegmenter );
  int rc2 = GrammarEngine.sol_FetchSentence(hSegmenter);
  string sentence2 = GrammarEngine.sol_GetFetchedSentenceFX( hSegmenter );
*/


  // Проверим, что там есть русский лексикон.
  int ie1 = GrammarEngine.sol_FindEntry( hEngine, "МАМА", SolarixGrammarEngineNET.GrammarEngineAPI.NOUN_ru, SolarixGrammarEngineNET.GrammarEngineAPI.RUSSIAN_LANGUAGE );
  if( ie1==-1 )
   {
    Console.WriteLine("Russian language is missing in lexicon.");
    return;
   } 

  // Доступ к базе N-грамм.
  // В состав SDK входит крошечная база с сотней записей.
  
  // Получим общее количество записей в разбивке по типам и порядкам.
  // монограммы - это фактически слова
  UInt64 ngram_count1 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 1 );
  UInt64 ngram_count2 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 2 );
  UInt64 ngram_count3 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 3 );
  UInt64 ngram_count4 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 4 );
  // и пентаграммы
  UInt64 ngram_count5 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 5 );

  // теперь частота образцовых паттернов
  int freq11 = GrammarEngine.sol_Seek1Grams( hEngine, 0, "СОБАКА" ); // без лемматизации
  int freq12 = GrammarEngine.sol_Seek1Grams( hEngine, 1, "СОБАКА" ); // с лемматизацией
 
  int freq21 = GrammarEngine.sol_Seek2Grams( hEngine, 0, "СОБАКА", "И" );
  int freq22 = GrammarEngine.sol_Seek2Grams( hEngine, 1, "СОБАКА", "И" );
 
  int freq31 = GrammarEngine.sol_Seek3Grams( hEngine, 0, "СОБАКА", "И", "КОШКА" );
  int freq32 = GrammarEngine.sol_Seek3Grams( hEngine, 1, "СОБАКА", "И", "КОШКА" );
  
  int freq41 = GrammarEngine.sol_Seek4Grams( hEngine, 0, "СОБАКА", "И", "КОШКА", "НАШЛИ" );
  int freq42 = GrammarEngine.sol_Seek4Grams( hEngine, 1, "СОБАКА", "И", "КОШКА", "НАШЛИ" );
 
  int freq51 = GrammarEngine.sol_Seek5Grams( hEngine, 0, "СОБАКА", "И", "КОШКА", "НАШЛИ", "БОЛЬШОЕ" );
  int freq52 = GrammarEngine.sol_Seek5Grams( hEngine, 1, "СОБАКА", "И", "КОШКА", "НАШЛИ", "БОЛЬШОЕ" );



  // Работа с токенизатором, морфоанализатором, тезаурусом и морфосинтезатором.

  string phrase = "Мама мыла раму";

  // http://www.solarix.ru/api/ru/sol_Tokenize.shtml
  IntPtr hTokens = GrammarEngine.sol_TokenizeW( hEngine, phrase, GrammarEngineAPI.RUSSIAN_LANGUAGE );

  // http://www.solarix.ru/api/ru/sol_CountStrings.shtml
  int ntok =  GrammarEngine.sol_CountStrings( hTokens );
 
  if( ntok!=3 )
   {
    Console.WriteLine( "Error: number of tokens in phrase must be 3" );
    return;
   }

  StringBuilder tok_buf = new StringBuilder(100);

  // http://www.solarix.ru/api/ru/sol_GetString.shtml
  GrammarEngine.sol_GetStringW( hTokens, 0, tok_buf );
  string Subj = tok_buf.ToString();
  GrammarEngine.sol_GetStringW( hTokens, 1, tok_buf );
  string Verb = tok_buf.ToString();
  GrammarEngine.sol_GetStringW( hTokens, 2, tok_buf );
  string Obj = tok_buf.ToString();

  GrammarEngine.sol_DeleteStrings( hTokens );

  // Поставим подлежащее в множественное число, глагол - в будущее время (а также множественное число -
  // для согласования с подлежащим).

  // Проекция подлежащего.

  // http://www.solarix.ru/api/ru/sol_ProjectWord.shtml
  IntPtr hCoord_Subj = GrammarEngine.sol_ProjectWord( hEngine, Subj, 0 );

  // http://www.solarix.ru/api/ru/sol_CountProjections.shtml
  int nproj_subj = GrammarEngine.sol_CountProjections( hCoord_Subj );

  // словарная статья подлежащего
  // http://www.solarix.ru/api/ru/sol_GetIEntry.shtml
  int ie_subj = GrammarEngine.sol_GetIEntry(hCoord_Subj,0);

  // грамматический род подлежащего
  // http://www.solarix.ru/api/ru/sol_GetProjCoordState.shtml
  int subj_gender = GrammarEngine.sol_GetProjCoordState( hEngine, hCoord_Subj, 0, SolarixGrammarEngineNET.GrammarEngineAPI.GENDER_ru );

  // удаляем результаты, освобождаем память
  // http://www.solarix.ru/api/ru/sol_DeleteProjections.shtml
  GrammarEngine.sol_DeleteProjections(hCoord_Subj);

  // склонение подлежащего
  // http://www.solarix.ru/api/ru/sol_GetNounForm.shtml
  int rc_subj = GrammarEngine.sol_GetNounForm(
                                              hEngine,
                                              ie_subj,
                                              SolarixGrammarEngineNET.GrammarEngineAPI.PLURAL_NUMBER_ru,
                                              SolarixGrammarEngineNET.GrammarEngineAPI.NOMINATIVE_CASE_ru,
                                              tok_buf
                                             );    
  Subj = tok_buf.ToString(); // получили лексическое представление новой формы подлежащего.
  
  // Проекция глагольной части сказуемого.
  IntPtr hCoord_Verb = GrammarEngine.sol_ProjectWord( hEngine, Verb, 0 );
  int nproj_verb = GrammarEngine.sol_CountProjections( hCoord_Verb );
  // Словарная статья глагола. Ой! А тут нам простоту портит омонимия - "мыла"
  // может быть и родительным падежом существительного "МЫЛО".
  int ie_verb = -1;

  for( int iproj=0; iproj<nproj_verb; ++iproj )
   {
    int ie = GrammarEngine.sol_GetIEntry(hCoord_Verb,0);
    int iclass = GrammarEngine.sol_GetEntryClass( hEngine, ie );
    if( iclass == SolarixGrammarEngineNET.GrammarEngineAPI.VERB_ru )
     {
      ie_verb=ie;
      break;
     }
   }

  GrammarEngine.sol_DeleteProjections(hCoord_Verb);

  // Нам надо получить неопределенную форму глагола. Фактически имя словарной статьи для
  // глаголов в 99.999% случаев совпадает с инфинитивом, но мы пойдем другим путем - сделаем
  // запрос через тезаурус.
  int ie_inf=-1;
  IntPtr hVerbLinks = GrammarEngine.sol_SeekThesaurus(
                                                      hEngine,
                                                      ie_verb, 
                                                      0, // синонимы не нужны
                                                      1, // нужны именно грамматические связи
                                                      0, // переводы не нужны
                                                      0, // семантические связи не нужны
                                                      1 // непосредственно связанные  
                                                     );
  if( hVerbLinks.ToInt32()!=0 )
   {
    // Отфильтруем инфинитивы.
    int n_linked = GrammarEngine.sol_CountInts( hVerbLinks );
    if( n_linked>0 )
     {
      for( int il=0; il<n_linked; ++il )
       {
        int ientry = GrammarEngine.sol_GetInt(hVerbLinks,il);
        if( ientry!=ie_verb )
         {
          int iclass = GrammarEngine.sol_GetEntryClass( hEngine, ientry );
          if( iclass==SolarixGrammarEngineNET.GrammarEngineAPI.INFINITIVE_ru )
           {
            // нашелся инфинитив - дальше не смотрим.
            ie_inf = ientry;
            break;  
           } 
         }
        
       } 

      GrammarEngine.sol_DeleteInts( hVerbLinks );

      // Глагол БЫТЬ пригодится для формирования будущего глагольного времени.
      int ie_be = GrammarEngine.sol_FindEntry( hEngine, "БЫТЬ", SolarixGrammarEngineNET.GrammarEngineAPI.VERB_ru, SolarixGrammarEngineNET.GrammarEngineAPI.RUSSIAN_LANGUAGE );

      // Надо только проспрягать его в нужную форму
      int rc_be = GrammarEngine.sol_GetVerbForm(
                                                hEngine, 
                                                ie_be,
                                                SolarixGrammarEngineNET.GrammarEngineAPI.PLURAL_NUMBER_ru,
                                                subj_gender, // формально укажем род подлежащего, хотя для будущего времени он игнорируется в парадигмах русских глаголов  
                                                SolarixGrammarEngineNET.GrammarEngineAPI.FUTURE_ru,
                                                SolarixGrammarEngineNET.GrammarEngineAPI.PERSON_3_ru,
                                                tok_buf
                                               );    
      string be_form = tok_buf.ToString();

      GrammarEngine.sol_GetEntryName( hEngine, ie_inf, tok_buf );
      string inf_form = tok_buf.ToString();

      Verb = be_form + " " + inf_form;
     }
   }
  
  // Собираем обратно все предложение. Должно получится что-то вроде "МАМЫ БУДУТ МЫТЬ РАМУ"
  string phrase2 = Subj + " " + Verb + " " + Obj; 

  // ********************************************************
  // Проверяем работу синтаксического анализатора.
  // ********************************************************

  string sent = "пила злобно лежит на дубовом столе";
  IntPtr hPack = GrammarEngine.sol_SyntaxAnalysis( hEngine, sent, 0, 0, 60000, GrammarEngineAPI.RUSSIAN_LANGUAGE );

  // Выберем граф с минимальным количеством корневых узлов
  // http://www.solarix.ru/api/ru/sol_CountGrafs.shtml
  int ngrafs = GrammarEngine.sol_CountGrafs(hPack);
  int imin_graf=-1, minv=2000000;
  for( int i=0; i<ngrafs; i++ )
   {
    // http://www.solarix.ru/api/ru/sol_CountRoots.shtml
    int nroots = GrammarEngine.sol_CountRoots(hPack,i);
    if( nroots<minv ) 
     {
      minv = nroots;
      imin_graf = i; 
     }  
   }

  // Распечатаем этот граф
  Console.Write( "Most completed graf:\n" );
  Int32 rCount = GrammarEngine.sol_CountRoots( hPack, imin_graf );
  for( int j=0; j < rCount; j++ )
   {
    // http://www.solarix.ru/api/ru/sol_GetRoot.shtml
    IntPtr hNode = GrammarEngine.sol_GetRoot(hPack, imin_graf, j);
    PrintNode(hNode);
    Console.Write( " " );
   }

  Console.Write( "\n" );

  return;
 }
}
} 