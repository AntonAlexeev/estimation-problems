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
    Console.WriteLine("������� ��������. ������: " + r.ToString());
   }
  else
   {
    Console.WriteLine("������ �������� �������.");
    return;
   }


/*
  IntPtr hSegmenter = GrammarEngine.sol_CreateSentenceBrokerMemW( hEngine, "Greenspan's fraud: how two decades of his policies have undermined the global economy. A delegate will often have a void return type.", -1 );
  int rc1 = GrammarEngine.sol_FetchSentence(hSegmenter);
  string sentence1 = GrammarEngine.sol_GetFetchedSentenceFX( hSegmenter );
  int rc2 = GrammarEngine.sol_FetchSentence(hSegmenter);
  string sentence2 = GrammarEngine.sol_GetFetchedSentenceFX( hSegmenter );
*/


  // ��������, ��� ��� ���� ������� ��������.
  int ie1 = GrammarEngine.sol_FindEntry( hEngine, "����", SolarixGrammarEngineNET.GrammarEngineAPI.NOUN_ru, SolarixGrammarEngineNET.GrammarEngineAPI.RUSSIAN_LANGUAGE );
  if( ie1==-1 )
   {
    Console.WriteLine("Russian language is missing in lexicon.");
    return;
   } 

  // ������ � ���� N-�����.
  // � ������ SDK ������ ��������� ���� � ������ �������.
  
  // ������� ����� ���������� ������� � �������� �� ����� � ��������.
  // ���������� - ��� ���������� �����
  UInt64 ngram_count1 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 1 );
  UInt64 ngram_count2 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 2 );
  UInt64 ngram_count3 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 3 );
  UInt64 ngram_count4 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 4 );
  // � �����������
  UInt64 ngram_count5 = GrammarEngine.sol_CountNGramsFX( hEngine, 1, 5 );

  // ������ ������� ���������� ���������
  int freq11 = GrammarEngine.sol_Seek1Grams( hEngine, 0, "������" ); // ��� ������������
  int freq12 = GrammarEngine.sol_Seek1Grams( hEngine, 1, "������" ); // � �������������
 
  int freq21 = GrammarEngine.sol_Seek2Grams( hEngine, 0, "������", "�" );
  int freq22 = GrammarEngine.sol_Seek2Grams( hEngine, 1, "������", "�" );
 
  int freq31 = GrammarEngine.sol_Seek3Grams( hEngine, 0, "������", "�", "�����" );
  int freq32 = GrammarEngine.sol_Seek3Grams( hEngine, 1, "������", "�", "�����" );
  
  int freq41 = GrammarEngine.sol_Seek4Grams( hEngine, 0, "������", "�", "�����", "�����" );
  int freq42 = GrammarEngine.sol_Seek4Grams( hEngine, 1, "������", "�", "�����", "�����" );
 
  int freq51 = GrammarEngine.sol_Seek5Grams( hEngine, 0, "������", "�", "�����", "�����", "�������" );
  int freq52 = GrammarEngine.sol_Seek5Grams( hEngine, 1, "������", "�", "�����", "�����", "�������" );



  // ������ � �������������, �����������������, ���������� � �����������������.

  string phrase = "���� ���� ����";

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

  // �������� ���������� � ������������� �����, ������ - � ������� ����� (� ����� ������������� ����� -
  // ��� ������������ � ����������).

  // �������� �����������.

  // http://www.solarix.ru/api/ru/sol_ProjectWord.shtml
  IntPtr hCoord_Subj = GrammarEngine.sol_ProjectWord( hEngine, Subj, 0 );

  // http://www.solarix.ru/api/ru/sol_CountProjections.shtml
  int nproj_subj = GrammarEngine.sol_CountProjections( hCoord_Subj );

  // ��������� ������ �����������
  // http://www.solarix.ru/api/ru/sol_GetIEntry.shtml
  int ie_subj = GrammarEngine.sol_GetIEntry(hCoord_Subj,0);

  // �������������� ��� �����������
  // http://www.solarix.ru/api/ru/sol_GetProjCoordState.shtml
  int subj_gender = GrammarEngine.sol_GetProjCoordState( hEngine, hCoord_Subj, 0, SolarixGrammarEngineNET.GrammarEngineAPI.GENDER_ru );

  // ������� ����������, ����������� ������
  // http://www.solarix.ru/api/ru/sol_DeleteProjections.shtml
  GrammarEngine.sol_DeleteProjections(hCoord_Subj);

  // ��������� �����������
  // http://www.solarix.ru/api/ru/sol_GetNounForm.shtml
  int rc_subj = GrammarEngine.sol_GetNounForm(
                                              hEngine,
                                              ie_subj,
                                              SolarixGrammarEngineNET.GrammarEngineAPI.PLURAL_NUMBER_ru,
                                              SolarixGrammarEngineNET.GrammarEngineAPI.NOMINATIVE_CASE_ru,
                                              tok_buf
                                             );    
  Subj = tok_buf.ToString(); // �������� ����������� ������������� ����� ����� �����������.
  
  // �������� ���������� ����� ����������.
  IntPtr hCoord_Verb = GrammarEngine.sol_ProjectWord( hEngine, Verb, 0 );
  int nproj_verb = GrammarEngine.sol_CountProjections( hCoord_Verb );
  // ��������� ������ �������. ��! � ��� ��� �������� ������ �������� - "����"
  // ����� ���� � ����������� ������� ���������������� "����".
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

  // ��� ���� �������� �������������� ����� �������. ���������� ��� ��������� ������ ���
  // �������� � 99.999% ������� ��������� � �����������, �� �� ������ ������ ����� - �������
  // ������ ����� ��������.
  int ie_inf=-1;
  IntPtr hVerbLinks = GrammarEngine.sol_SeekThesaurus(
                                                      hEngine,
                                                      ie_verb, 
                                                      0, // �������� �� �����
                                                      1, // ����� ������ �������������� �����
                                                      0, // �������� �� �����
                                                      0, // ������������� ����� �� �����
                                                      1 // ��������������� ���������  
                                                     );
  if( hVerbLinks.ToInt32()!=0 )
   {
    // ����������� ����������.
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
            // ������� ��������� - ������ �� �������.
            ie_inf = ientry;
            break;  
           } 
         }
        
       } 

      GrammarEngine.sol_DeleteInts( hVerbLinks );

      // ������ ���� ���������� ��� ������������ �������� ����������� �������.
      int ie_be = GrammarEngine.sol_FindEntry( hEngine, "����", SolarixGrammarEngineNET.GrammarEngineAPI.VERB_ru, SolarixGrammarEngineNET.GrammarEngineAPI.RUSSIAN_LANGUAGE );

      // ���� ������ ����������� ��� � ������ �����
      int rc_be = GrammarEngine.sol_GetVerbForm(
                                                hEngine, 
                                                ie_be,
                                                SolarixGrammarEngineNET.GrammarEngineAPI.PLURAL_NUMBER_ru,
                                                subj_gender, // ��������� ������ ��� �����������, ���� ��� �������� ������� �� ������������ � ���������� ������� ��������  
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
  
  // �������� ������� ��� �����������. ������ ��������� ���-�� ����� "���� ����� ���� ����"
  string phrase2 = Subj + " " + Verb + " " + Obj; 

  // ********************************************************
  // ��������� ������ ��������������� �����������.
  // ********************************************************

  string sent = "���� ������ ����� �� ������� �����";
  IntPtr hPack = GrammarEngine.sol_SyntaxAnalysis( hEngine, sent, 0, 0, 60000, GrammarEngineAPI.RUSSIAN_LANGUAGE );

  // ������� ���� � ����������� ����������� �������� �����
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

  // ����������� ���� ����
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