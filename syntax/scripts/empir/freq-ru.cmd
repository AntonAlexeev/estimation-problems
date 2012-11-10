@rem (c) by Elijah Koziev www.solarix.ru

@rem Скрипт обрабатывает файлы в указанном в ком. строке каталоге и выполняет их частотный анализ
@rem Это быстрая версия скрипта freq-slow-ru.cmd за счет 2х вещей:
@rem 1. Не делается статистический анализ на уровне букв (см. опцию -chars)

@echo off


IF DEFINED PROCESSOR_ARCHITEW6432 GOTO x64

..\..\exe\empirika.exe -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -scheme1 -russian -dir %1

GOTO End

:x64
..\..\exe64\empirika.exe -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -scheme1 -russian -dir %1

:End
