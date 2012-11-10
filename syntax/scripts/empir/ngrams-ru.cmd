@rem (c) by Elijah Koziev www.solarix.ru

@rem Получение статистики N-грамм для файлов в указанном каталоге.
@rem Параметры оптимизированы для небольшого размера текстов (<100 Мб)
@rem Доп. информация по утилите Empirika: www.solarix.ru/for_developers/exercise/la_project.shtml
@rem
@rem Запуск:  ngrams-ru каталог_с_файлами

@echo off

@del ..\..\tmp\ngrams
@del ..\..\tmp\ngram2
@del ..\..\tmp\ngram3
@del ..\..\tmp\ngram4
@del ..\..\tmp\ngram5
@del ..\..\tmp\ngram2_literal
@del ..\..\tmp\ngram3_literal
@del ..\..\tmp\ngram4_literal
@del ..\..\tmp\ngram5_literal

IF DEFINED PROCESSOR_ARCHITEW6432 GOTO x64

rem Delete results from previous run of EMPIRIKA

@del ..\..\bin-windows\NGRAMS

rem ..\..\exe\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -dbcache 100000000 -doccache 10000000 -ngramscache 15000000 -use_disk_cache -upload_to_db- -ngrams -1grams- -2grams -3grams- -correl_any -lemmatization -russian -dir %1
rem ..\..\exe\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -dbcache 100000000 -doccache 10000000 -ngramscache 15000000 -use_disk_cache -upload_to_db- -ngrams -1grams- -2grams- -3grams -correl_any -lemmatization -russian -dir %1
rem @Call cov2grams-ru %1

..\..\exe\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -dbcache 10000000 -doccache 10000000 -ngramscache 30000000 -use_disk_cache- -upload_to_db- -ngrams -1grams -2grams- -3grams- -4grams- -5grams- -correl_any -russian -dir %1
..\..\exe\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -dbcache 10000000 -doccache 10000000 -ngramscache 15000000 -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams -3grams- -4grams- -5grams- -correl_any -russian -dir %1
..\..\exe\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -dbcache 10000000 -doccache 5000000  -ngramscache 10000000 -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams- -3grams -4grams- -5grams- -correl_any -russian -dir %1
..\..\exe\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -dbcache 10000000 -doccache 2000000  -ngramscache 5000000  -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams- -3grams- -4grams -5grams- -correl_any -russian -dir %1
..\..\exe\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows -outdir ..\..\tmp -cp 1251 -dbcache 10000000 -doccache 2000000  -ngramscache 5000000  -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams- -3grams- -4grams- -5grams -correl_any -russian -dir %1

rem @copy ..\..\tmp\ngrams         ..\..\bin-windows\

GOTO End

:x64
rem Delete results from previous run of EMPIRIKA

@del ..\..\bin-windows64\NGRAMS

rem ..\..\exe64\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -dbcache 100000000 -doccache 60000000 -ngramscache 60000000 -use_disk_cache -upload_to_db- -ngrams -1grams- -2grams -3grams- -correl_any -lemmatization -russian -dir %1
rem ..\..\exe64\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -dbcache 100000000 -doccache 50000000 -ngramscache 50000000 -use_disk_cache -upload_to_db- -ngrams -1grams- -2grams- -3grams -correl_any -lemmatization -russian -dir %1
rem @Call cov2grams-ru %1

..\..\exe64\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -doccache 70000000 -ngramscache 230000000 -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams -3grams- -4grams- -5grams- -correl_any -russian -dir %1
..\..\exe64\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -doccache 50000000 -ngramscache 210000000 -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams- -3grams -4grams- -5grams- -correl_any -russian -dir %1
..\..\exe64\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -doccache 40000000 -ngramscache 150000000 -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams- -3grams- -4grams -5grams- -correl_any -russian -dir %1
..\..\exe64\empirika.exe -log ..\..\tmp\empirika.log -dictdir ..\..\bin-windows64 -outdir ..\..\tmp -cp 1251 -doccache 30000000 -ngramscache 120000000 -use_disk_cache- -upload_to_db- -ngrams -1grams- -2grams- -3grams- -4grams- -5grams -correl_any -russian -dir %1

rem @copy ..\..\tmp\ngrams         ..\..\bin-windows64\

:End

