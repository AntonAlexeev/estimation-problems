@rem (c) by Elijah Koziev www.solarix.ru

@rem ������ ������������ ����� � ��������� � ���. ������ �������� � ��������� �� ��������� ������
@rem ��� ������� ������ ������� freq-slow-ru.cmd �� ���� 2� �����:
@rem 1. �� �������� �������������� ������ �� ������ ���� (��. ����� -chars)

@echo off


IF DEFINED PROCESSOR_ARCHITEW6432 GOTO x64

..\..\exe\empirika.exe -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -scheme1 -russian -dir %1

GOTO End

:x64
..\..\exe64\empirika.exe -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -scheme1 -russian -dir %1

:End
