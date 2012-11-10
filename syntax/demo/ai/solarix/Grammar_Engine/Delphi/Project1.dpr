program Project1;
{$APPTYPE CONSOLE}

{ Это простой пример вызова процедур и функций API грамматического движка
  проекта Solarix Intellectronix

  Документация по API: http://www.solarix.ru/for_developers/api/grammar-engine-api.shtml

  Последние правки: 21.02.2012
 }

uses
  SysUtils,
  Windows,
  _sg_api in '..\..\..\..\..\include\lem\solarix\_sg_api.pas',
  GrammarEngineApi in '..\..\..\..\..\include\lem\solarix\GrammarEngineApi.pas';

procedure wide( text: PWideChar );
var buf: PAnsiChar;
var len: integer;
begin

 len := Length(text);

 buf := StrAlloc(len+1);

 WideCharToMultiByte( CP_OEMCP, 0, text, len+1, buf, len+1, nil, nil );
 Write( buf );

 StrDispose(buf);

end;



procedure PrintNode( hEngine: PInteger; hNode: PInteger );
var Buffer: PWideChar;
var hChild: PInteger;
var nleaf, ileaf: Integer;
begin

Buffer := PWideChar(StrAlloc( 80 ));

// http://www.solarix.ru/api/ru/sol_GetNodeContents.shtml
sol_GetNodeContents( hNode, Buffer );
wide(Buffer);

// http://www.solarix.ru/api/ru/sol_CountLeafs.shtml
nleaf := sol_CountLeafs(hNode);
if nleaf>0
 then begin

  Write( '(' );

  for ileaf:=0 to nleaf-1
   do begin

    // http://www.solarix.ru/api/ru/sol_GetLeaf.shtml
    hChild := sol_GetLeaf( hNode, ileaf );
    PrintNode( hEngine, hChild );

   end;

  Write( ' )' );

 end;

Write(' ');

StrDispose( PAnsiChar(Buffer) );

end;



var hEngine, hStrList, hIntList, hFG: PInteger;
var rc: integer;
var max_lexem: integer;
var nEntry, nForm, nLink: integer;
var Buffer, Buffer2: PWideChar;
var i, ie, ie2, iform, iclass, gender: integer;
var eng_kind, Major, Minor, Build, dict_ver: integer;
var n_forms: integer;
var hCoordList: PInteger;
var n_proj: integer;
var RandomString: PWideChar;
var ngram_count1, ngram_count2, ngram_count3, ngram_count4, ngram_count5: Int64;
var freq11, freq12, freq21, freq22, freq31, freq32, freq41, freq42, freq51, freq52: integer;
var id_phrase1, id_phrase2, id_phrase3: integer;
var phrase_text: WideString;
var hPack: PInteger;
var nlinkage, nroot, ncoord, icoord, ilinkage, iroot, nstates: integer;
var EntryID, PartOfSpeechID, CoordID, StateID: integer;
var hNode: PInteger;
var hLinkList: PInteger;
var nlinks, link_type: integer;
begin

 Buffer := nil;
 Buffer2 := nil;

 WriteLn( 'Loading dictionary...' );

 // Загружаем словарь и создаем экземпляр грамматического движка.
 // http://www.solarix.ru/api/ru/sol_CreateGrammarEngine.shtml
 hEngine := sol_CreateGrammarEngineA( '..\..\..\..\..\bin-windows\dictionary.xml' );

 // Загрузился?
 if( hEngine<>nil )
  then begin

  WriteLn( 'Dictionary is loaded.' );

  // Уровень движка: 0-Lite, 1-Pro, 2-Premium
  eng_kind := sol_GetVersion( hEngine, @Major, @Minor, @Build );
  WriteLn( 'Engine type: ' + IntToStr(eng_kind) +
           ' version: ' + IntToStr(Major) + '.' + IntToStr(Minor) + '.' + IntToStr(Build) );

  // Номер версии словаря, как он определен в исходниках словаря. Для Lite словарей
  // это всегда 0, для Pro - число >=10, для Premium число >=1000.
  dict_ver := sol_DictionaryVersion(hEngine);
  WriteLn( 'Dictionary version: ' + IntToStr(dict_ver) );

  // Максимальная длина лексем - может быть полезна при объявлении
  // различных буферов для работы с отдельными словами.
  max_lexem := sol_MaxLexemLen(hEngine);
  WriteLn( 'Max lexem length=' + IntToStr(max_lexem) + ' wide chars' );

  Buffer := PWideChar(StrAlloc( 2*(max_lexem+1) ));
  Buffer2 := PWideChar(StrAlloc( 2*(max_lexem+1) ));

  // Статистика лексикона и тезауруса.
  nEntry := sol_CountEntries(hEngine); // http://www.solarix.ru/api/ru/sol_CountEntries.shtml
  nLink := sol_CountLinks(hEngine);

  WriteLn( 'Entries count ='+IntToStr(nEntry) );
  WriteLn( 'Links count   ='+IntToStr(nLink) );

  id_phrase1 := sol_FindPhrase( hEngine, WideString('грамматический словарь русского языка'), 0 );
  id_phrase2 := sol_AddPhrase( hEngine, WideString('проверяем добавление фразы'), -1, -1, 0 );
  id_phrase3 := sol_FindPhrase( hEngine, WideString('проверяем добавление фразы'), 0 );

  phrase_text := sol_GetPhraseTextPAS( hEngine, id_phrase3 );
  sol_DeletePhrase( hEngine, id_phrase3 );


  // Доступ к базе N-грамм.
  // В состав SDK входит крошечная база с сотней записей.
  
  // Получим общее количество записей в разбивке по типам и порядкам.
  ngram_count1 := sol_CountNGrams64( hEngine, 1, 1 );
  ngram_count2 := sol_CountNGrams64( hEngine, 1, 2 );
  ngram_count3 := sol_CountNGrams64( hEngine, 1, 3 );
  ngram_count4 := sol_CountNGrams64( hEngine, 1, 4 );
  ngram_count5 := sol_CountNGrams64( hEngine, 1, 5 );
  WriteLn( '#1=', ngram_count1 ); 
  WriteLn( '#2=', ngram_count2 );
  WriteLn( '#3=', ngram_count3 );
  WriteLn( '#4=', ngram_count4 );
  WriteLn( '#5=', ngram_count5 );

  // теперь частота образцовых паттернов
  freq11 := sol_Seek1Grams( hEngine, 0, 'СОБАКА' ); // без лемматизации
  freq12 := sol_Seek1Grams( hEngine, 1, 'СОБАКА' ); // с лемматизацией
  WriteLn( 'freq=', freq11, ', ', freq12 );

  freq21 := sol_Seek2Grams( hEngine, 0, 'СОБАКА', 'И' );
  freq22 := sol_Seek2Grams( hEngine, 1, 'СОБАКА', 'И' );
  WriteLn( 'freq=', freq21, ', ', freq22 );

  freq31 := sol_Seek3Grams( hEngine, 0, 'СОБАКА', 'И', 'КОШКА' );
  freq32 := sol_Seek3Grams( hEngine, 1, 'СОБАКА', 'И', 'КОШКА' );
  WriteLn( 'freq=', freq31, ', ', freq32 );

  freq41 := sol_Seek4Grams( hEngine, 0, 'СОБАКА', 'И', 'КОШКА', 'НАШЛИ' );
  freq42 := sol_Seek4Grams( hEngine, 1, 'СОБАКА', 'И', 'КОШКА', 'НАШЛИ' );
  WriteLn( 'freq=', freq41, ', ', freq42 );

  freq51 := sol_Seek5Grams( hEngine, 0, 'СОБАКА', 'И', 'КОШКА', 'НАШЛИ', 'БОЛЬШОЕ' );
  freq52 := sol_Seek5Grams( hEngine, 1, 'СОБАКА', 'И', 'КОШКА', 'НАШЛИ', 'БОЛЬШОЕ' );
  WriteLn( 'freq=', freq51, ', ', freq52 );

  // Поиск словарной статьи по ее базовой форме. Для существительного
  // базовая форма - это именительный падеж единственное число.
  StringToWideChar('РОССИЯ',Buffer, max_lexem );
  // http://www.solarix.ru/api/ru/sol_FindEntry.shtml
  ie := sol_FindEntry( hEngine, Buffer, -1, -1 );
  WriteLn( 'ie='+IntToStr(ie) );

  if ie<>-1
   then begin

    // http://www.solarix.ru/api/ru/sol_FindWord.shtml
    rc := sol_FindWord( hEngine, Buffer, @ie2, @iform, @iclass );
    if rc<>1
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    if ie<>ie2
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    if iclass<>NOUN_ru
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    // Получим обратно имя словарной статьи по ее ключу
    // http://www.solarix.ru/api/ru/sol_GetEntryName.shtml
    rc := sol_GetEntryName( hEngine, ie, Buffer );

    // Часть речи, к которому относится статья
    // http://www.solarix.ru/api/ru/sol_GetEntryClass.shtml
    iclass := sol_GetEntryClass( hEngine, ie );

    // Должно быть существительное.
    if iclass<>NOUN_ru
     then begin
      WriteLn( 'Invalid class' );
      Exit;
     end;

    // Грамматический род является атрибутом для существительных.
    // http://www.solarix.ru/api/ru/sol_GetCoordType.shtml
    if sol_GetCoordType( hEngine, GENDER_ru, iclass )<>0
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    // Можно получить имя части речи, как оно объявлено в словаре.
    // http://www.solarix.ru/api/ru/sol_GetClassName.shtml
    sol_GetClassName( hEngine, iclass, Buffer );
    wide(Buffer);
    WriteLn('');

    // Грамматический род существительного.
    // http://www.solarix.ru/api/ru/sol_GetNounGender.shtml
    gender := sol_GetNounGender( hEngine, ie );

    // Должен быть женский
    if gender<>FEMININE_GENDER_ru
     then begin
      WriteLn( 'Invalid gender' );
      Exit;
     end;

    StringToWideChar('РОССИЯ',Buffer, max_lexem );

    // Раз уж мы нашли словарную статью, то получим лексическое представление
    // каждой ее словоформы, а также связанных словарных статей.
    hStrList := sol_FindStringsEx(
                                  hEngine,
                                  Buffer,
                                  0,
                                  1, // синонимы
                                  1, // грамматические связи
                                  1, // переводы
                                  1, // семантические связи
                                  0 );

    // Сколько словоформ получилось?
    // http://www.solarix.ru/api/ru/sol_CountStrings.shtml
    n_forms := sol_CountStrings(hStrList);

    for i:=0 to n_forms-1
     do begin

      sol_GetStringW( hStrList, i, Buffer );
      wide(Buffer);
      WriteLn('');

     end;

    // Не забываем освобождать ресурсы
    sol_DeleteStrings(hStrList); hStrList:=nil;

    // Склонение существительного - в творительный падеж множественного числа.
    // http://www.solarix.ru/api/ru/sol_GetNounForm.shtml
    rc := sol_GetNounForm( hEngine, ie, PLURAL_NUMBER_ru, INSTRUMENTAL_CASE_ru, Buffer );
    wide(Buffer);
    WriteLn('');

    // Другая процедура склонения - согласование с числительным
    // 'ДВЕ РОССИИ'
    rc := sol_CorrNounNumber( hEngine, ie, 2 {две}, NOMINATIVE_CASE_ru, INANIMATIVE_FORM_ru, Buffer2 );

    StringToWideChar('РОССИИ', Buffer, max_lexem );
    if WideCompareStr(Buffer,Buffer2)<>0
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    // Поиск для словоформы 'РОССИИ' должен дать тот же id словарной статьи,
    // что и для 'РОССИЯ'
    ie2 := sol_SeekWord( hEngine, Buffer2, 0 );
    if ie<>ie2
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    // Приведем слово 'РОССИИ' к базовой форме - именительный падеж единственного числа
    rc := sol_TranslateToBase( hEngine, Buffer2, 0 );

    // Число в текстовое представление
    rc := sol_Value2Text( hEngine, Buffer2, 2, FEMININE_GENDER_ru );

    // Ниже показан переход от прилагательного к грамматически связанному с ним
    // существительному РОССИЙСКИЙ-РОССИЯ
    StringToWideChar('РОССИЙСКИЙ', Buffer2, max_lexem );
    ie2 := sol_FindEntry( hEngine, Buffer2, -1, -1 );
    ie2 := sol_TranslateToNoun( hEngine, ie2 );
    sol_GetEntryName( hEngine, ie2, Buffer2 );
    wide(Buffer);
    WriteLn('');

    // Поиск в тезаурусе связанных статей
    // В ознакомительной версии не будет работать из-за урезанного тезауруса.
    hLinkList := sol_ListLinksTxt( hEngine, ie, -1, 0 );
    nlinks := sol_LinksInfoCount( hEngine, hLinkList );

    for i:=0 to nlinks-1
     do begin

      ie2 := sol_LinksInfoEKey2( hEngine, hLinkList, i );
      link_type := sol_LinksInfoCode( hEngine, hLinkList, i );

      WriteLn( 'ie2=', ie2, ' link_type=', link_type );

     end;


    sol_DeleteLinksInfo( hEngine, hLinkList );

   end;

  // Пример лемматизации - приведения слова к базовой форме.
  // Обратите внимание, что исходное слово должно быть приведено
  // к верхнему регистру - это требование текущих версий ГМ.
  StringToWideChar('ГАЛАКТИЧЕСКОЮ',Buffer, max_lexem );
  rc := sol_LemmatizeWord( hEngine, Buffer, 1 );
  wide(Buffer);
  WriteLn('');


  // Проверим проекцию слов на лексикон, то есть изолированный морфологический
  // анализ. При этом не фильтруются омонимы - движок возвращает все возможные
  // варианты распознавания словоформы.
  StringToWideChar( 'ПИЛА', Buffer, max_lexem );
  hCoordList := sol_ProjectWord( hEngine, Buffer, 0 ); // http://www.solarix.ru/api/ru/sol_ProjectWord.shtml
  n_proj := sol_CountProjections(hCoordList); // http://www.solarix.ru/api/ru/sol_CountProjections.shtml

  // Должно быть 2 проекции - существительное ПИЛА ед.ч. им.п и личная форма
  // глагола ПИТЬ прош.вр. ед.ч. ж.р.
  for i:=0 to n_proj-1
   do begin

    // http://www.solarix.ru/api/ru/sol_GetIEntry.shtml
    ie := sol_GetIEntry( hCoordList, i );

    // http://www.solarix.ru/api/ru/sol_GetEntryName.shtml
    rc := sol_GetEntryName( hEngine, ie, Buffer );
    wide(Buffer);
    Write(' ');

    iclass := sol_GetEntryClass( hEngine, ie );
    sol_GetClassName( hEngine, iclass, Buffer );
    wide(Buffer);
    WriteLn('');

   end;

  // http://www.solarix.ru/api/ru/sol_DeleteProjections.shtml
  sol_DeleteProjections(hCoordList); hCoordList:=nil;

  { морфологический анализ http://www.solarix.ru/for_developers/docs/morphology_analyzer.shtml }
  hPack := sol_MorphologyAnalysisA( hEngine, PAnsiChar('Толстый пушистый кот сладко спит на диване'), 0, 0, 100000, RUSSIAN_LANGUAGE );

 // перебираем альтернативные варианты анализа. в большинстве случаев он 1.
 // http://www.solarix.ru/api/ru/sol_CountGrafs.shtml
 nlinkage := sol_CountGrafs( hPack );
 for ilinkage:=0 to nlinkage-1
  do begin

   // цикл по деревьям. в случае морфоанализа деревья имеют по 1му корню.
   // самый первое и последнее дерево пропускаем - это специальные метки начала
   // и конца предложения.
   // http://www.solarix.ru/api/ru/sol_CountRoots.shtml
   nroot := sol_CountRoots( hPack, ilinkage );
   for iroot:=1 to nroot-2
    do begin

     hNode := sol_GetRoot( hPack, ilinkage, iroot );

     Write( 'Word ', iroot, ' ' );

     // текстовое представление словоформы для этого узла
     sol_GetNodeContents( hNode, Buffer );
     wide(Buffer);
     Write( ' part of speech=' );

     // получим наименование части речи
     // http://www.solarix.ru/api/ru/sol_GetNodeIEntry.shtml
     EntryID := sol_GetNodeIEntry( hEngine, hNode );
     PartOfSpeechID := sol_GetEntryClass( hEngine, EntryID );
     sol_GetClassName( hEngine, PartOfSpeechID, Buffer );
     wide(Buffer);

     Write( ' attributes:' );

     // выведем все грамматические признаки для словоформы
     // http://www.solarix.ru/api/ru/sol_GetNodePairsCount.shtml
     ncoord := sol_GetNodePairsCount(hNode);
     for icoord:=0 to ncoord-1
      do begin

       CoordID := sol_GetNodePairCoord( hNode, icoord ); // http://www.solarix.ru/api/ru/sol_GetNodePairCoord.shtml
       StateID := sol_GetNodePairState( hNode, icoord ); // http://www.solarix.ru/api/ru/sol_GetNodePairState.shtml

       // Некоторые признаки не имеют явно определенных состояний, а
       // представляют из себя логические маркеры с неявными состояниями 0 и 1.
       // http://www.solarix.ru/api/ru/sol_CountCoordStates.shtml
       nstates := sol_CountCoordStates( hEngine, CoordID );
       if nstates=0
        then begin

         Write( ' ' );

         // Если состояние=0, то это отсутствие маркируемого признака,
         // например не краткая форма прилагательного.
         if StateID=0 then Write( '~' );

         // http://www.solarix.ru/api/ru/sol_GetCoordName.shtml
         sol_GetCoordName( hEngine, CoordID, Buffer );
         wide( Buffer );

        end else begin

         sol_GetCoordName( hEngine, CoordID, Buffer );
         Write( ' ' );
         wide( Buffer );
         Write( ':' );

         Buffer[0] := #0;
         // http://www.solarix.ru/api/ru/sol_GetCoordStateName.shtml
         sol_GetCoordStateName( hEngine, CoordID, StateID, Buffer );
         wide( Buffer );

        end

      end;

     WriteLn('');

    end;

  end;

 // http://www.solarix.ru/api/ru/sol_DeleteResPack.shtml
 sol_DeleteResPack(hPack);

 { синтаксический анализ - определение грамматических связей и построение графа }
 // http://www.solarix.ru/api/ru/sol_SyntaxAnalysis.shtml
 hPack := sol_SyntaxAnalysisA( hEngine, PAnsiChar('Толстый пушистый кот сладко спит на диване'), 0, 0, 100000, RUSSIAN_LANGUAGE );

 nlinkage := sol_CountGrafs( hPack );
 for ilinkage:=0 to nlinkage-1
  do begin

   nroot := sol_CountRoots( hPack, ilinkage );
   for iroot:=1 to nroot-2
    do begin

     hNode := sol_GetRoot( hPack, ilinkage, iroot );
     PrintNode( hEngine, hNode );

    end;

   WriteLn('');

  end;

 sol_DeleteResPack(hPack);


 // Выгружаем словарь и убиваем объект движка.
 // http://www.solarix.ru/api/ru/sol_DeleteGrammarEngine.shtml
 rc := sol_DeleteGrammarEngine(hEngine);


 StrDispose( PAnsiChar(Buffer) );
 StrDispose( PAnsiChar(Buffer2) );

 end;

end.


