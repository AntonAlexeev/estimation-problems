program Project1;

{$APPTYPE CONSOLE}

uses
  SysUtils, Dialogs,
  LemmatizatorEngineApi in '..\..\..\..\..\..\include\lem\solarix\LemmatizatorEngineApi.pas';

var
  hE: Pointer;
  cl: Integer;
  myLemma: PAnsiChar;
  myStr: String;
  hLemmas: Pointer;
  i, n: integer;

begin

  // �������� ������� �� �������� API: http://www.solarix.ru/for_developers/api/lemmatizator-api.shtml

  // �������������� ������ � ��������� ���� ������ ������������
  hE := sol_LoadLemmatizatorA('..\..\..\..\..\..\bin-windows\lemmatizer.db',LEME_DEFAULT);

  myStr := '��������';
  GetMem( myLemma, 32 );
  // ������� sol_GetLemma[A,W,8] ���� ������������ �������, ���� ���� ���� ��������������.
  cl := sol_GetLemmaA( hE, PAnsiChar(myStr), myLemma, 32 );
  ShowMessage( myLemma );

  // ��� ����� ���� ������ �������� ��� ����� - ��������� ���� � ��������� �����
  // ���������������� ���. ������� sol_GetLemmas[A,W,8] ���������� ����������
  // ������ ����.
  hLemmas := sol_GetLemmasA( hE, PAnsiChar('����') );
  if( hLemmas<>nil )
   then begin

    n := sol_Countlemmas( hLemmas );
    for i:=0 to n-1
     do begin

      sol_GetLemmaStringA( hLemmas, i, myLemma, 32 );
      ShowMessage( myLemma );

     end;

    sol_DeleteLemmas(hLemmas);

   end;

  sol_DeleteLemmatizator(hE);
  
end.
