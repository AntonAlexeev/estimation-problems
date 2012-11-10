#include <stdio.h>
#include <string.h>
#include <windows.h>
#include <lem/solarix/solarix_grammar_engine.h>


int main( int argc, char *argv[] )
{
 // Create the instance of grammatical engine and connect the local database.
 // SOL_GREN_LAZY_LEXICON instructs the engine to load the word entries when they needed
 // http://www.solarix.ru/api/sol_CreateGrammarEngine.shtml
 HGREN hEngine = sol_CreateGrammarEngineEx8( "..\\..\\..\\..\\..\\bin-windows\\dictionary.xml", SOL_GREN_LAZY_LEXICON );

 char sentence[] = "Кошки ели мой корм"; // This .cpp file is utf-8

 // Buffers for some text information
 char * EntryName = new char[ sol_MaxLexemLen8(hEngine) ];
 char * PartOfSpeechName = new char[ sol_MaxLexemLen8(hEngine) ];
 char * Word = new char[ sol_MaxLexemLen8(hEngine) ];

 // Split the sentence into words.
 // http://www.solarix.ru/api/sol_Tokenize.shtml
 HGREN_STR hWords = sol_Tokenize8( hEngine, sentence, -1 );

 int nword = sol_CountStrings(hWords); // http://www.solarix.ru/api/sol_CountStrings.shtml
 for( int i=0; i<nword; ++i )
 {
  sol_GetString8( hWords, i, Word ); // extract next word http://www.solarix.ru/api/sol_GetString.shtml

  HGREN_WCOORD hProjs = sol_ProjectWord8( hEngine, Word, 0 ); // look for the word forms in dictionary http://www.solarix.ru/api/sol_ProjectWord.shtml

  int nprojs = sol_CountProjections(hProjs); // http://www.solarix.ru/api/sol_CountProjections.shtml
  
  for( int i=0; i<nprojs; ++i )
   {
    int id_entry = sol_GetIEntry(hProjs,i); // http://www.solarix.ru/api/sol_GetIEntry.shtml
    int id_partofspeech = sol_GetEntryClass( hEngine, id_entry ); // http://www.solarix.ru/api/sol_GetEntryClass.shtml

    sol_GetEntryName8( hEngine, id_entry, EntryName ); // http://www.solarix.ru/api/sol_GetEntryName.shtml
    sol_GetClassName8( hEngine, id_partofspeech, PartOfSpeechName ); // http://www.solarix.ru/api/sol_GetClassName.shtml

    // ...
   }

  sol_DeleteProjections(hProjs); // http://www.solarix.ru/api/sol_DeleteProjections.shtml
 }

 sol_DeleteStrings(hWords); // http://www.solarix.ru/api/sol_DeleteStrings.shtml
 sol_DeleteGrammarEngine(hEngine); // http://www.solarix.ru/api/sol_DeleteGrammarEngine.shtml

 return 0;
}

