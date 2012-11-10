program Project1;
{$APPTYPE CONSOLE}

{ ��� ������� ������ ������ �������� � ������� API ��������������� ������
  ������� Solarix Intellectronix

  ������������ �� API: http://www.solarix.ru/for_developers/api/grammar-engine-api.shtml

  ��������� ������: 21.02.2012
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

 // ��������� ������� � ������� ��������� ��������������� ������.
 // http://www.solarix.ru/api/ru/sol_CreateGrammarEngine.shtml
 hEngine := sol_CreateGrammarEngineA( '..\..\..\..\..\bin-windows\dictionary.xml' );

 // ����������?
 if( hEngine<>nil )
  then begin

  WriteLn( 'Dictionary is loaded.' );

  // ������� ������: 0-Lite, 1-Pro, 2-Premium
  eng_kind := sol_GetVersion( hEngine, @Major, @Minor, @Build );
  WriteLn( 'Engine type: ' + IntToStr(eng_kind) +
           ' version: ' + IntToStr(Major) + '.' + IntToStr(Minor) + '.' + IntToStr(Build) );

  // ����� ������ �������, ��� �� ��������� � ���������� �������. ��� Lite ��������
  // ��� ������ 0, ��� Pro - ����� >=10, ��� Premium ����� >=1000.
  dict_ver := sol_DictionaryVersion(hEngine);
  WriteLn( 'Dictionary version: ' + IntToStr(dict_ver) );

  // ������������ ����� ������ - ����� ���� ������� ��� ����������
  // ��������� ������� ��� ������ � ���������� �������.
  max_lexem := sol_MaxLexemLen(hEngine);
  WriteLn( 'Max lexem length=' + IntToStr(max_lexem) + ' wide chars' );

  Buffer := PWideChar(StrAlloc( 2*(max_lexem+1) ));
  Buffer2 := PWideChar(StrAlloc( 2*(max_lexem+1) ));

  // ���������� ��������� � ���������.
  nEntry := sol_CountEntries(hEngine); // http://www.solarix.ru/api/ru/sol_CountEntries.shtml
  nLink := sol_CountLinks(hEngine);

  WriteLn( 'Entries count ='+IntToStr(nEntry) );
  WriteLn( 'Links count   ='+IntToStr(nLink) );

  id_phrase1 := sol_FindPhrase( hEngine, WideString('�������������� ������� �������� �����'), 0 );
  id_phrase2 := sol_AddPhrase( hEngine, WideString('��������� ���������� �����'), -1, -1, 0 );
  id_phrase3 := sol_FindPhrase( hEngine, WideString('��������� ���������� �����'), 0 );

  phrase_text := sol_GetPhraseTextPAS( hEngine, id_phrase3 );
  sol_DeletePhrase( hEngine, id_phrase3 );


  // ������ � ���� N-�����.
  // � ������ SDK ������ ��������� ���� � ������ �������.
  
  // ������� ����� ���������� ������� � �������� �� ����� � ��������.
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

  // ������ ������� ���������� ���������
  freq11 := sol_Seek1Grams( hEngine, 0, '������' ); // ��� ������������
  freq12 := sol_Seek1Grams( hEngine, 1, '������' ); // � �������������
  WriteLn( 'freq=', freq11, ', ', freq12 );

  freq21 := sol_Seek2Grams( hEngine, 0, '������', '�' );
  freq22 := sol_Seek2Grams( hEngine, 1, '������', '�' );
  WriteLn( 'freq=', freq21, ', ', freq22 );

  freq31 := sol_Seek3Grams( hEngine, 0, '������', '�', '�����' );
  freq32 := sol_Seek3Grams( hEngine, 1, '������', '�', '�����' );
  WriteLn( 'freq=', freq31, ', ', freq32 );

  freq41 := sol_Seek4Grams( hEngine, 0, '������', '�', '�����', '�����' );
  freq42 := sol_Seek4Grams( hEngine, 1, '������', '�', '�����', '�����' );
  WriteLn( 'freq=', freq41, ', ', freq42 );

  freq51 := sol_Seek5Grams( hEngine, 0, '������', '�', '�����', '�����', '�������' );
  freq52 := sol_Seek5Grams( hEngine, 1, '������', '�', '�����', '�����', '�������' );
  WriteLn( 'freq=', freq51, ', ', freq52 );

  // ����� ��������� ������ �� �� ������� �����. ��� ����������������
  // ������� ����� - ��� ������������ ����� ������������ �����.
  StringToWideChar('������',Buffer, max_lexem );
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

    // ������� ������� ��� ��������� ������ �� �� �����
    // http://www.solarix.ru/api/ru/sol_GetEntryName.shtml
    rc := sol_GetEntryName( hEngine, ie, Buffer );

    // ����� ����, � �������� ��������� ������
    // http://www.solarix.ru/api/ru/sol_GetEntryClass.shtml
    iclass := sol_GetEntryClass( hEngine, ie );

    // ������ ���� ���������������.
    if iclass<>NOUN_ru
     then begin
      WriteLn( 'Invalid class' );
      Exit;
     end;

    // �������������� ��� �������� ��������� ��� ���������������.
    // http://www.solarix.ru/api/ru/sol_GetCoordType.shtml
    if sol_GetCoordType( hEngine, GENDER_ru, iclass )<>0
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    // ����� �������� ��� ����� ����, ��� ��� ��������� � �������.
    // http://www.solarix.ru/api/ru/sol_GetClassName.shtml
    sol_GetClassName( hEngine, iclass, Buffer );
    wide(Buffer);
    WriteLn('');

    // �������������� ��� ����������������.
    // http://www.solarix.ru/api/ru/sol_GetNounGender.shtml
    gender := sol_GetNounGender( hEngine, ie );

    // ������ ���� �������
    if gender<>FEMININE_GENDER_ru
     then begin
      WriteLn( 'Invalid gender' );
      Exit;
     end;

    StringToWideChar('������',Buffer, max_lexem );

    // ��� �� �� ����� ��������� ������, �� ������� ����������� �������������
    // ������ �� ����������, � ����� ��������� ��������� ������.
    hStrList := sol_FindStringsEx(
                                  hEngine,
                                  Buffer,
                                  0,
                                  1, // ��������
                                  1, // �������������� �����
                                  1, // ��������
                                  1, // ������������� �����
                                  0 );

    // ������� ��������� ����������?
    // http://www.solarix.ru/api/ru/sol_CountStrings.shtml
    n_forms := sol_CountStrings(hStrList);

    for i:=0 to n_forms-1
     do begin

      sol_GetStringW( hStrList, i, Buffer );
      wide(Buffer);
      WriteLn('');

     end;

    // �� �������� ����������� �������
    sol_DeleteStrings(hStrList); hStrList:=nil;

    // ��������� ���������������� - � ������������ ����� �������������� �����.
    // http://www.solarix.ru/api/ru/sol_GetNounForm.shtml
    rc := sol_GetNounForm( hEngine, ie, PLURAL_NUMBER_ru, INSTRUMENTAL_CASE_ru, Buffer );
    wide(Buffer);
    WriteLn('');

    // ������ ��������� ��������� - ������������ � ������������
    // '��� ������'
    rc := sol_CorrNounNumber( hEngine, ie, 2 {���}, NOMINATIVE_CASE_ru, INANIMATIVE_FORM_ru, Buffer2 );

    StringToWideChar('������', Buffer, max_lexem );
    if WideCompareStr(Buffer,Buffer2)<>0
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    // ����� ��� ���������� '������' ������ ���� ��� �� id ��������� ������,
    // ��� � ��� '������'
    ie2 := sol_SeekWord( hEngine, Buffer2, 0 );
    if ie<>ie2
     then begin
      WriteLn( 'Error' );
      Exit;
     end;

    // �������� ����� '������' � ������� ����� - ������������ ����� ������������� �����
    rc := sol_TranslateToBase( hEngine, Buffer2, 0 );

    // ����� � ��������� �������������
    rc := sol_Value2Text( hEngine, Buffer2, 2, FEMININE_GENDER_ru );

    // ���� ������� ������� �� ��������������� � ������������� ���������� � ���
    // ���������������� ����������-������
    StringToWideChar('����������', Buffer2, max_lexem );
    ie2 := sol_FindEntry( hEngine, Buffer2, -1, -1 );
    ie2 := sol_TranslateToNoun( hEngine, ie2 );
    sol_GetEntryName( hEngine, ie2, Buffer2 );
    wide(Buffer);
    WriteLn('');

    // ����� � ��������� ��������� ������
    // � ��������������� ������ �� ����� �������� ��-�� ���������� ���������.
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

  // ������ ������������ - ���������� ����� � ������� �����.
  // �������� ��������, ��� �������� ����� ������ ���� ���������
  // � �������� �������� - ��� ���������� ������� ������ ��.
  StringToWideChar('�������������',Buffer, max_lexem );
  rc := sol_LemmatizeWord( hEngine, Buffer, 1 );
  wide(Buffer);
  WriteLn('');


  // �������� �������� ���� �� ��������, �� ���� ������������� ���������������
  // ������. ��� ���� �� ����������� ������� - ������ ���������� ��� ���������
  // �������� ������������� ����������.
  StringToWideChar( '����', Buffer, max_lexem );
  hCoordList := sol_ProjectWord( hEngine, Buffer, 0 ); // http://www.solarix.ru/api/ru/sol_ProjectWord.shtml
  n_proj := sol_CountProjections(hCoordList); // http://www.solarix.ru/api/ru/sol_CountProjections.shtml

  // ������ ���� 2 �������� - ��������������� ���� ��.�. ��.� � ������ �����
  // ������� ���� ����.��. ��.�. �.�.
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

  { ��������������� ������ http://www.solarix.ru/for_developers/docs/morphology_analyzer.shtml }
  hPack := sol_MorphologyAnalysisA( hEngine, PAnsiChar('������� �������� ��� ������ ���� �� ������'), 0, 0, 100000, RUSSIAN_LANGUAGE );

 // ���������� �������������� �������� �������. � ����������� ������� �� 1.
 // http://www.solarix.ru/api/ru/sol_CountGrafs.shtml
 nlinkage := sol_CountGrafs( hPack );
 for ilinkage:=0 to nlinkage-1
  do begin

   // ���� �� ��������. � ������ ������������ ������� ����� �� 1�� �����.
   // ����� ������ � ��������� ������ ���������� - ��� ����������� ����� ������
   // � ����� �����������.
   // http://www.solarix.ru/api/ru/sol_CountRoots.shtml
   nroot := sol_CountRoots( hPack, ilinkage );
   for iroot:=1 to nroot-2
    do begin

     hNode := sol_GetRoot( hPack, ilinkage, iroot );

     Write( 'Word ', iroot, ' ' );

     // ��������� ������������� ���������� ��� ����� ����
     sol_GetNodeContents( hNode, Buffer );
     wide(Buffer);
     Write( ' part of speech=' );

     // ������� ������������ ����� ����
     // http://www.solarix.ru/api/ru/sol_GetNodeIEntry.shtml
     EntryID := sol_GetNodeIEntry( hEngine, hNode );
     PartOfSpeechID := sol_GetEntryClass( hEngine, EntryID );
     sol_GetClassName( hEngine, PartOfSpeechID, Buffer );
     wide(Buffer);

     Write( ' attributes:' );

     // ������� ��� �������������� �������� ��� ����������
     // http://www.solarix.ru/api/ru/sol_GetNodePairsCount.shtml
     ncoord := sol_GetNodePairsCount(hNode);
     for icoord:=0 to ncoord-1
      do begin

       CoordID := sol_GetNodePairCoord( hNode, icoord ); // http://www.solarix.ru/api/ru/sol_GetNodePairCoord.shtml
       StateID := sol_GetNodePairState( hNode, icoord ); // http://www.solarix.ru/api/ru/sol_GetNodePairState.shtml

       // ��������� �������� �� ����� ���� ������������ ���������, �
       // ������������ �� ���� ���������� ������� � �������� ����������� 0 � 1.
       // http://www.solarix.ru/api/ru/sol_CountCoordStates.shtml
       nstates := sol_CountCoordStates( hEngine, CoordID );
       if nstates=0
        then begin

         Write( ' ' );

         // ���� ���������=0, �� ��� ���������� ������������ ��������,
         // �������� �� ������� ����� ���������������.
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

 { �������������� ������ - ����������� �������������� ������ � ���������� ����� }
 // http://www.solarix.ru/api/ru/sol_SyntaxAnalysis.shtml
 hPack := sol_SyntaxAnalysisA( hEngine, PAnsiChar('������� �������� ��� ������ ���� �� ������'), 0, 0, 100000, RUSSIAN_LANGUAGE );

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


 // ��������� ������� � ������� ������ ������.
 // http://www.solarix.ru/api/ru/sol_DeleteGrammarEngine.shtml
 rc := sol_DeleteGrammarEngine(hEngine);


 StrDispose( PAnsiChar(Buffer) );
 StrDispose( PAnsiChar(Buffer2) );

 end;

end.


