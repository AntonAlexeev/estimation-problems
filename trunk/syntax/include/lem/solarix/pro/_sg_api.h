// This file is generated 13.08.2012 14:05:54 by Ygres compiler ver. 11.33.10090 Standard Win32  (build date Aug 13 2012).
// Languages
const int RUSSIAN_LANGUAGE = 2;                    // language Russian
const int ENGLISH_LANGUAGE = 3;                    // language English
const int FRENCH_LANGUAGE = 4;                     // language French
const int SPANISH_LANGUAGE = 5;                    // language Spanish
const int CHINESE_LANGUAGE = 6;                    // language Chinese
const int JAPANESE_LANGUAGE = 7;                   // language Japanese
const int GERMAN_LANGUAGE = 8;                     // language German
const int THESAURUS_LANGUAGE = 9;                  // language ThesaurusLanguage
// ------------------------------------------------------------


const int NUM_WORD_CLASS = 3;                      // class num_word
const int NOUN_ru = 9;                             // class СУЩЕСТВИТЕЛЬНОЕ
const int PRONOUN2_ru = 10;                        // class МЕСТОИМ_СУЩ
const int PRONOUN_ru = 11;                         // class МЕСТОИМЕНИЕ
const int ADJ_ru = 12;                             // class ПРИЛАГАТЕЛЬНОЕ
const int NUMBER_CLASS_ru = 13;                    // class ЧИСЛИТЕЛЬНОЕ
const int INFINITIVE_ru = 14;                      // class ИНФИНИТИВ
const int VERB_ru = 15;                            // class ГЛАГОЛ
const int GERUND_2_ru = 16;                        // class ДЕЕПРИЧАСТИЕ
const int PREPOS_ru = 17;                          // class ПРЕДЛОГ
const int IMPERSONAL_VERB_ru = 18;                 // class БЕЗЛИЧ_ГЛАГОЛ
const int PARTICLE_ru = 21;                        // class ЧАСТИЦА
const int CONJ_ru = 22;                            // class СОЮЗ
const int ADVERB_ru = 23;                          // class НАРЕЧИЕ
const int PUNCTUATION_class = 24;                  // class ПУНКТУАТОР
const int VERB_en = 29;                            // class ENG_VERB
const int NOUN_en = 30;                            // class ENG_NOUN
const int PRONOUN_en = 31;                         // class ENG_PRONOUN
const int ARTICLE_en = 32;                         // class ENG_ARTICLE
const int PREP_en = 33;                            // class ENG_PREP
const int CONJ_en = 34;                            // class ENG_CONJ
const int ADV_en = 35;                             // class ENG_ADVERB
const int ADJ_en = 36;                             // class ENG_ADJECTIVE
const int PARTICLE_en = 37;                        // class ENG_PARTICLE
const int NUMERAL_en = 38;                         // class ENG_NUMERAL
const int INTERJECTION_en = 39;                    // class ENG_INTERJECTION
const int NUMERAL_fr = 40;                         // class FR_NUMERAL
const int ARTICLE_fr = 41;                         // class FR_ARTICLE
const int PREP_fr = 42;                            // class FR_PREP
const int ADV_fr = 43;                             // class FR_ADVERB
const int CONJ_fr = 44;                            // class FR_CONJ
const int NOUN_fr = 45;                            // class FR_NOUN
const int ADJ_fr = 46;                             // class FR_ADJ
const int PRONOUN_fr = 47;                         // class FR_PRONOUN
const int VERB_fr = 48;                            // class FR_VERB
const int PARTICLE_fr = 49;                        // class FR_PARTICLE
const int PRONOUN2_fr = 50;                        // class FR_PRONOUN2
const int NOUN_es = 51;                            // class ES_NOUN
const int ROOT_es = 52;                            // class ES_ROOT
const int JAP_NOUN = 53;                           // class JAP_NOUN
const int JAP_NUMBER = 54;                         // class JAP_NUMBER
const int JAP_ADJECTIVE = 55;                      // class JAP_ADJECTIVE
const int JAP_ADVERB = 56;                         // class JAP_ADVERB
const int JAP_CONJ = 57;                           // class JAP_CONJ
const int JAP_VERB = 58;                           // class JAP_VERB
const int JAP_PRONOUN = 59;                        // class JAP_PRONOUN
const int JAP_VERB_POSTFIX2 = 62;                  // class JAP_VERB_POSTFIX2
const int JAP_PARTICLE = 64;                       // class JAP_PARTICLE
const int UNKNOWN_ENTRIES_CLASS = 75;              // class UnknownEntries
// ------------------------------------------------------------



const int CharCasing = 5;                          // enum CharCasing
// Coordiname CharCasing states:
const int DECAPITALIZED_CASED = 0;                 // CharCasing : Lower
const int FIRST_CAPITALIZED_CASED = 1;             // CharCasing : FirstCapitalized
const int ALL_CAPITALIZED_CASED = 2;               // CharCasing : Upper
const int EACH_LEXEM_CAPITALIZED_CASED = 3;        // CharCasing : EachLexemCapitalized

const int PERSON_xx = 7;                           // enum PERSON
// Coordiname PERSON states:
const int PERSON_1_xx = 0;                         // PERSON : 1
const int PERSON_2_xx = 1;                         // PERSON : 2
const int PERSON_3_xx = 2;                         // PERSON : 3

const int NUMBER_xx = 8;                           // enum NUMBER
// Coordiname NUMBER states:
const int SINGLE_xx = 0;                           // NUMBER : SINGLE
const int PLURAL_xx = 1;                           // NUMBER : PLURAL

const int GENDER_xx = 9;                           // enum GENDER
// Coordiname GENDER states:
const int MASCULINE_xx = 0;                        // GENDER : MASCULINE
const int FEMININE_xx = 1;                         // GENDER : FEMININE
const int NEUTRAL_xx = 2;                          // GENDER : NEUTRAL

const int SPEECH_STYLE_xx = 10;                    // enum СтильРечи
// Coordiname СтильРечи states:

const int STRENGTH_xx = 11;                        // enum РазмерСила
// Coordiname РазмерСила states:

const int PERSON_ru = 12;                          // enum ЛИЦО
// Coordiname ЛИЦО states:
const int PERSON_1_ru = 0;                         // ЛИЦО : 1
const int PERSON_2_ru = 1;                         // ЛИЦО : 2
const int PERSON_3_ru = 2;                         // ЛИЦО : 3

const int NUMBER_ru = 13;                          // enum ЧИСЛО
// Coordiname ЧИСЛО states:
const int SINGULAR_NUMBER_ru = 0;                  // ЧИСЛО : ЕД
const int PLURAL_NUMBER_ru = 1;                    // ЧИСЛО : МН

const int GENDER_ru = 14;                          // enum РОД
// Coordiname РОД states:
const int MASCULINE_GENDER_ru = 0;                 // РОД : МУЖ
const int FEMININE_GENDER_ru = 1;                  // РОД : ЖЕН
const int NEUTRAL_GENDER_ru = 2;                   // РОД : СР

const int TRANSITIVENESS_ru = 15;                  // enum ПЕРЕХОДНОСТЬ
// Coordiname ПЕРЕХОДНОСТЬ states:
const int NONTRANSITIVE_VERB_ru = 0;               // ПЕРЕХОДНОСТЬ : НЕПЕРЕХОДНЫЙ
const int TRANSITIVE_VERB_ru = 1;                  // ПЕРЕХОДНОСТЬ : ПЕРЕХОДНЫЙ

const int PARTICIPLE_ru = 16;                      // enum ПРИЧАСТИЕ

const int PASSIVE_PARTICIPLE_ru = 17;              // enum СТРАД

const int ASPECT_ru = 18;                          // enum ВИД
// Coordiname ВИД states:
const int PERFECT_ru = 0;                          // ВИД : СОВЕРШ
const int IMPERFECT_ru = 1;                        // ВИД : НЕСОВЕРШ

const int VERB_FORM_ru = 20;                       // enum НАКЛОНЕНИЕ
// Coordiname НАКЛОНЕНИЕ states:
const int VB_INF_ru = 0;                           // НАКЛОНЕНИЕ : ИЗЪЯВ
const int VB_ORDER_ru = 1;                         // НАКЛОНЕНИЕ : ПОБУД

const int TENSE_ru = 21;                           // enum ВРЕМЯ
// Coordiname ВРЕМЯ states:
const int PAST_ru = 0;                             // ВРЕМЯ : ПРОШЕДШЕЕ
const int PRESENT_ru = 1;                          // ВРЕМЯ : НАСТОЯЩЕЕ
const int FUTURE_ru = 2;                           // ВРЕМЯ : БУДУЩЕЕ

const int SHORTNESS_ru = 22;                       // enum КРАТКИЙ

const int VOICE_ru = 23;                           // enum ЗАЛОГ
// Coordiname ЗАЛОГ states:
const int PASSIVE_VOICE_ru = 0;                    // ЗАЛОГ : СТРАД
const int ACTIVE_VOICE_ru = 1;                     // ЗАЛОГ : ДЕЙСТВ

const int CASE_ru = 26;                            // enum ПАДЕЖ
// Coordiname ПАДЕЖ states:
const int NOMINATIVE_CASE_ru = 0;                  // ПАДЕЖ : ИМ
const int VOCATIVE_CASE_ru = 1;                    // ЗВАТ
const int GENITIVE_CASE_ru = 2;                    // ПАДЕЖ : РОД
const int PARTITIVE_CASE_ru = 3;                   // ПАРТ
const int INSTRUMENTAL_CASE_ru = 5;                // ПАДЕЖ : ТВОР
const int ACCUSATIVE_CASE_ru = 6;                  // ПАДЕЖ : ВИН
const int DATIVE_CASE_ru = 7;                      // ПАДЕЖ : ДАТ
const int PREPOSITIVE_CASE_ru = 8;                 // ПАДЕЖ : ПРЕДЛ
const int LOCATIVE_CASE_ru = 10;                   // МЕСТ

const int FORM_ru = 27;                            // enum ОДУШ
// Coordiname ОДУШ states:
const int ANIMATIVE_FORM_ru = 0;                   // ОДУШ : ОДУШ
const int INANIMATIVE_FORM_ru = 1;                 // ОДУШ : НЕОДУШ

const int COUNTABILITY_ru = 28;                    // enum ПЕРЕЧИСЛИМОСТЬ
// Coordiname ПЕРЕЧИСЛИМОСТЬ states:
const int COUNTABLE_ru = 0;                        // ПЕРЕЧИСЛИМОСТЬ : ДА
const int UNCOUNTABLE_ru = 1;                      // ПЕРЕЧИСЛИМОСТЬ : НЕТ

const int COMPAR_FORM_ru = 29;                     // enum СТЕПЕНЬ
// Coordiname СТЕПЕНЬ states:
const int ATTRIBUTIVE_FORM_ru = 0;                 // СТЕПЕНЬ : АТРИБ
const int COMPARATIVE_FORM_ru = 1;                 // СТЕПЕНЬ : СРАВН
const int SUPERLATIVE_FORM_ru = 2;                 // СТЕПЕНЬ : ПРЕВОСХ

const int CASE_GERUND_ru = 30;                     // enum ПадежВал
// Coordiname ПадежВал states:

const int MODAL_ru = 31;                           // enum МОДАЛЬНЫЙ

const int VERBMODE_TENSE = 32;                     // enum СГД_Время
// Coordiname СГД_Время states:

const int VERBMODE_DIRECTION = 33;                 // enum СГД_Направление
// Coordiname СГД_Направление states:

const int TENSE_en = 34;                           // enum TENSE
// Coordiname TENSE states:
const int PAST_en = 0;                             // TENSE : PAST
const int PRESENT_en = 1;                          // TENSE : PRESENT
const int FUTURE_en = 2;                           // TENSE : FUTURE

const int DURATION_en = 35;                        // enum DURATION
// Coordiname DURATION states:
const int SIMPLE_en = 0;                           // DURATION : INDEFINITE
const int CONTINUOUS_en = 1;                       // DURATION : CONTINUOUS
const int PERFECT_en = 2;                          // DURATION : PERFECT
const int PERFECT_CONTINUOS_en = 3;                // DURATION : PERFECT_CONTINUOUS

const int VOICE_en = 36;                           // enum VOICE
// Coordiname VOICE states:
const int PASSIVE_en = 0;                          // VOICE : PASSIVE
const int ACTIVE_en = 1;                           // VOICE : ACTIVE

const int CASE_en = 37;                            // enum CASE
// Coordiname CASE states:
const int NOMINATIVE_CASE_en = 0;                  // CASE : NOMINATIVE
const int PREPOSITIVE_CASE_en = 1;                 // CASE : PREPOSITIVE

const int NOUN_FORM_en = 38;                       // enum NOUN_FORM
// Coordiname NOUN_FORM states:
const int BASIC_NOUN_FORM_en = 0;                  // NOUN_FORM : BASIC
const int POSSESSIVE_NOUN_FORM_en = 1;             // NOUN_FORM : POSSESSIVE

const int PRONOUN_FORM_en = 39;                    // enum PRONOUN_FORM
// Coordiname PRONOUN_FORM states:

const int ADJ_FORM_en = 40;                        // enum ADJ_FORM
// Coordiname ADJ_FORM states:
const int BASIC_ADJ_en = 0;                        // ADJ_FORM : BASIC
const int COMPARATIVE_ADJ_en = 1;                  // ADJ_FORM : COMPARATIVE
const int SUPERLATIVE_ADJ_en = 2;                  // ADJ_FORM : SUPERLATIVE

const int COMPARABILITY_en = 41;                   // enum COMPARABILITY
// Coordiname COMPARABILITY states:
const int ANALYTIC_en = 0;                         // COMPARABILITY : ANALYTIC
const int SYNTHETIC_en = 1;                        // COMPARABILITY : SYNTHETIC
const int COMPARABLE_en = 2;                       // COMPARABILITY : COMPARABLE
const int NONCOMPARABLE = 3;                       // COMPARABILITY : NONCOMPARABLE

const int VERB_FORM_en = 42;                       // enum VERB_FORM
// Coordiname VERB_FORM states:
const int UNDEF_VERBFORM_en = 0;                   // VERB_FORM : UNDEF
const int ED_VERBFORM_en = 1;                      // VERB_FORM : ED
const int ING_VERBFORM_en = 2;                     // VERB_FORM : ING
const int PP_VERBFORM_en = 3;                      // VERB_FORM : PP
const int INF_VEBFORM_en = 4;                      // VERB_FORM : INF

const int ARTICLE_FORM = 43;                       // enum ARTICLE_FORM
// Coordiname ARTICLE_FORM states:
const int ARTICLE_FORM_1 = 0;                      // ARTICLE_FORM : 1
const int ARTICLE_FORM_2 = 1;                      // ARTICLE_FORM : 2

const int ENG_MODALITY = 44;                       // enum ENG_MODALITY
// Coordiname ENG_MODALITY states:
const int DIRECT_MODALITY_en = 0;                  // ENG_MODALITY : Direct
const int TO_MODALITY_en = 2;                      // ENG_MODALITY : To

const int NUMERAL_FORM_en = 45;                    // enum NUMERAL_FORM
// Coordiname NUMERAL_FORM states:
const int CARDINAL_en = 0;                         // NUMERAL_FORM : CARDINAL
const int ORDINAL_en = 1;                          // NUMERAL_FORM : ORDINAL

const int GENDER_en = 46;                          // enum ENG_GENDER
// Coordiname ENG_GENDER states:
const int MASCULINE_en = 0;                        // ENG_GENDER : MASCULINE
const int FEMININE_en = 1;                         // ENG_GENDER : FEMININE

const int TRANSITIVITY_en = 47;                    // enum TRANSITIVITY
// Coordiname TRANSITIVITY states:
const int INTRANSITIVE_VERB_en = 0;                // TRANSITIVITY : INTRANSITIVE
const int TRANSITIVE_VERB_en = 1;                  // TRANSITIVITY : TRANSITIVE

const int OBLIG_TRANSITIVITY_en = 48;              // enum OBLIG_TRANSITIVITY

const int PROPER_NOUN_en = 49;                     // enum ENG_PROPER_NOUN

const int MASS_NOUN_en = 50;                       // enum ENG_MASS_NOUN

const int PERSON_fr = 51;                          // enum FR_PERSON
// Coordiname FR_PERSON states:
const int PERSON_1_fr = 0;                         // FR_PERSON : 1
const int PERSON_2_fr = 1;                         // FR_PERSON : 2
const int PERSON_3_fr = 2;                         // FR_PERSON : 3

const int NUMBER_fr = 52;                          // enum FR_NOMBRE
// Coordiname FR_NOMBRE states:
const int SINGULAR_fr = 0;                         // FR_NOMBRE : SINGULIER
const int PLURAL_fr = 1;                           // FR_NOMBRE : PLURIEL

const int GENDER_fr = 53;                          // enum FR_GENRE
// Coordiname FR_GENRE states:
const int MASCULINE_fr = 0;                        // FR_GENRE : MASCULINE
const int FEMININE_fr = 1;                         // FR_GENRE : FEMININE

const int FR_NUMERAL_FORM = 54;                    // enum FR_NUMERAL_FORM
// Coordiname FR_NUMERAL_FORM states:
const int CARDINAL_fr = 0;                         // FR_NUMERAL_FORM : CARDINAL
const int ORDINAL_fr = 1;                          // FR_NUMERAL_FORM : ORDINAL

const int FR_PRONOUN_FORM = 55;                    // enum FR_PRONOUN_FORM
// Coordiname FR_PRONOUN_FORM states:
const int FR_PRONOUN_WEAK = 0;                     // FR_PRONOUN_FORM : WEAK
const int FR_PRONOUN_STRONG = 1;                   // FR_PRONOUN_FORM : STRONG

const int TRANSITIVITY_fr = 56;                    // enum FR_TRANSITIVITY
// Coordiname FR_TRANSITIVITY states:
const int INTRANSITIVE_VERB_fr = 0;                // FR_TRANSITIVITY : INTRANSITIVE
const int TRANSITIVE_VERB_fr = 1;                  // FR_TRANSITIVITY : TRANSITIVE

const int VERB_FORM_fr = 57;                       // enum FR_VERB_FORM
// Coordiname FR_VERB_FORM states:
const int INFINITIVE_fr = 0;                       // FR_VERB_FORM : INFINITIVE
const int PRESENT_VF_fr = 1;                       // FR_VERB_FORM : PRESENT
const int FUTURE_VF_fr = 2;                        // FR_VERB_FORM : FUTURE
const int IMPERFECT_VB_fr = 3;                     // FR_VERB_FORM : IMPERFECT
const int SIMPLE_PAST_fr = 4;                      // FR_VERB_FORM : SIMPLE_PAST
const int PRESENT_PARTICIPLE_fr = 5;               // FR_VERB_FORM : PRESENT_PARTICIPLE
const int PAST_PARTICIPLE_fr = 6;                  // FR_VERB_FORM : PAST_PARTICIPLE
const int SUBJUNCTIVE_PRESENT_fr = 7;              // FR_VERB_FORM : SUBJUNCTIVE_PRESENT
const int SUBJUNCTIVE_IMPERFECT_fr = 8;            // FR_VERB_FORM : SUBJUNCTIVE_IMPERFECT
const int CONDITIONAL_fr = 9;                      // FR_VERB_FORM : CONDITIONAL
const int IMPERATIVE_fr = 10;                      // FR_VERB_FORM : IMPERATIVE

const int JAP_FORM = 58;                           // enum JAP_FORM
// Coordiname JAP_FORM states:
const int KANA_FORM = 0;                           // JAP_FORM : KANA
const int KANJI_FORM = 1;                          // JAP_FORM : KANJI
const int ROMAJI_FORM = 2;                         // JAP_FORM : ROMAJI

const int JAP_VERB_BASE = 59;                      // enum JAP_VERB_BASE
// Coordiname JAP_VERB_BASE states:
const int JAP_VB_I = 0;                            // JAP_VERB_BASE : I
const int JAP_VB_II = 1;                           // JAP_VERB_BASE : II
const int JAP_VB_III = 2;                          // JAP_VERB_BASE : III
const int JAP_VB_IV = 3;                           // JAP_VERB_BASE : IV
const int JAP_VB_V = 4;                            // JAP_VERB_BASE : V
const int JAP_VB_PAST = 5;                         // JAP_VERB_BASE : PAST
const int JAP_VB_PARTICIPLE = 6;                   // JAP_VERB_BASE : PARTICIPLE
const int JAP_VB_POTENTIAL = 7;                    // JAP_VERB_BASE : POTENTIAL
const int JAP_VB_CONDITIONAL = 8;                  // JAP_VERB_BASE : CONDITIONAL
const int JAP_VB_CAUSATIVE = 9;                    // JAP_VERB_BASE : CAUSATIVE

const int JAP_VERB_KIND = 60;                      // enum JAP_VERB_KIND
// Coordiname JAP_VERB_KIND states:
const int JAP_PRESENT_FUTURE = 1;                  // JAP_VERB_KIND : PRESENT_FUTURE
const int JAP_NEGATIVE_PRESENT_FUTURE = 3;         // JAP_VERB_KIND : NEGATIVE_PRESENT_FUTURE
const int JAP_NEGATIVE_PAST = 4;                   // JAP_VERB_KIND : NEGATIVE_PAST
const int JAP_IMPERATIVE = 5;                      // JAP_VERB_KIND : IMPERATIVE
const int JAP_NEGATIVE_IMPERATIVE = 6;             // JAP_VERB_KIND : NEGATIVE_IMPERATIVE

const int JAP_ADJ_BASE = 61;                       // enum JAP_ADJ_BASE
// Coordiname JAP_ADJ_BASE states:
const int JAP_AB_I = 0;                            // JAP_ADJ_BASE : I
const int JAP_AB_II = 1;                           // JAP_ADJ_BASE : II
const int JAP_AB_III = 2;                          // JAP_ADJ_BASE : III
const int JAP_AB_IV = 3;                           // JAP_ADJ_BASE : IV
const int JAP_AB_V = 4;                            // JAP_ADJ_BASE : V
const int JAP_AB_T = 5;                            // JAP_ADJ_BASE : T
const int JAP_AB_PAST = 6;                         // JAP_ADJ_BASE : PAST

const int JAP_ADJ_FORM2 = 62;                      // enum JAP_ADJ_FORM2
// Coordiname JAP_ADJ_FORM2 states:
const int JAP_NEGATIVE_PRESENT_ADJ = 0;            // JAP_ADJ_FORM2 : NEGATIVE_PRESENT
const int JAP_NEGATIVE_PAST_ADJ = 1;               // JAP_ADJ_FORM2 : NEGATIVE_PAST

const int JAP_TRANSITIVE = 63;                     // enum JAP_TRANSITIVE

const int CASE_jap = 64;                           // enum JAP_CASE
// Coordiname JAP_CASE states:
const int VOCATIVE_jap = 0;                        // JAP_CASE : VOCATIVE
const int NOMINATIVE_THEM_jap = 1;                 // JAP_CASE : NOMINATIVE_THEM
const int NOMINATIVE_RHEM_jap = 2;                 // JAP_CASE : NOMINATIVE_RHEM
const int ACCUSATIVE_jap = 3;                      // JAP_CASE : ACCUSATIVE
const int GENITIVE_jap = 4;                        // JAP_CASE : GENITIVE
const int DATIVE_jap = 5;                          // JAP_CASE : DATIVE
const int ALLATIVE_jap = 6;                        // JAP_CASE : ALLATIVE
const int INSTRUMENTATIVE_jap = 7;                 // JAP_CASE : INSTRUMENTATIVE
const int ELATIVE_jap = 8;                         // JAP_CASE : ELATIVE
const int LIMITIVE_jap = 9;                        // JAP_CASE : LIMITIVE
const int COMPARATIVE_jap = 10;                    // JAP_CASE : COMPARATIVE
const int COMITATIVE_jap = 11;                     // JAP_CASE : COMITATIVE
const int SOCIATIVE_jap = 12;                      // JAP_CASE : SOCIATIVE

const int GENDER_jap = 65;                         // enum JAP_GENDER
// Coordiname JAP_GENDER states:
const int MASCULINE_jap = 0;                       // JAP_GENDER : MASCULINE
const int FEMININE_jap = 1;                        // JAP_GENDER : FEMININE

const int PERSON_jap = 66;                         // enum JAP_PERSON
// Coordiname JAP_PERSON states:
const int PERSON_1_jap = 0;                        // JAP_PERSON : 1
const int PERSON_2_jap = 1;                        // JAP_PERSON : 2
const int PERSON_3_jap = 2;                        // JAP_PERSON : 3

const int NUMBER_jap = 67;                         // enum JAP_NUMBER
// Coordiname JAP_NUMBER states:
const int SINGULAR_jap = 0;                        // JAP_NUMBER : SINGULAR
const int PLURAL_jap = 1;                          // JAP_NUMBER : PLURAL

const int JAP_PRONOUN_TYPE = 68;                   // enum JAP_PRONOUN_TYPE
// Coordiname JAP_PRONOUN_TYPE states:
const int PERSONAL_jap = 0;                        // JAP_PRONOUN_TYPE : PERSONAL
const int POINTING_jap = 1;                        // JAP_PRONOUN_TYPE : POINTING
const int POSSESSIVE_jap = 2;                      // JAP_PRONOUN_TYPE : POSSESSIVE
// ------------------------------------------------------------


const int OBJECT_link = 3;
const int ATTRIBUTE_link = 4;
const int CONDITION_link = 5;
const int CONSEQUENCE_link = 6;
const int LOGIC_ITEM_link = 7;
const int SUBJECT_link = 8;
const int RHEMA_link = 9;
const int COVERB_link = 10;
const int NUMBER2OBJ_link = 16;
const int TENSE_VERB_link = 31;
const int JAP_COMITATIVE_link = 33;
const int JAP_COMITATIVE2_link = 34;
const int TO_VERB_link = 35;
const int TO_INF_link = 36;
const int TO_PERFECT = 37;
const int TO_UNPERFECT = 38;
const int TO_NOUN_link = 39;
const int TO_ADJ_link = 40;
const int TO_ADV_link = 41;
const int TO_RETVERB = 42;
const int TO_GERUND_2_link = 43;
const int WOUT_RETVERB = 44;
const int TO_ENGLISH_link = 45;
const int TO_RUSSIAN_link = 46;
const int TO_FRENCH_link = 47;
const int SYNONYM_link = 48;
const int SEX_SYNONYM_link = 49;
const int CLASS_link = 50;
const int MEMBER_link = 51;
const int TO_SPANISH_link = 52;
const int TO_GERMAN_link = 53;
const int TO_CHINESE_link = 54;
const int TO_POLAND_link = 55;
const int TO_ITALIAN_link = 56;
const int TO_PORTUGUAL_link = 57;
const int ACTION_link = 58;
const int ACTOR_link = 59;
const int TOOL_link = 60;
const int RESULT_link = 61;
const int TO_JAPANESE_link = 62;
const int TO_KANA_link = 63;
const int TO_KANJI_link = 64;
const int ANTONYM_link = 65;
const int EXPLANATION_link = 66;
const int WWW_link = 67;
const int ACCENT_link = 68;
const int YO_link = 69;
const int TO_DIMINUITIVE_link = 70;
const int TO_RUDE_link = 71;
const int TO_BIGGER_link = 72;
const int TO_NEUTRAL_link = 73;
const int TO_SCOLARLY = 74;
const int TO_SAMPLE_link = 75;
const int USAGE_TAG_link = 76;
const int DOUBLE_LETTERS_link = 77;
const int PROPERTY_link = 78;
const int TO_CYRIJI_link = 79;
const int HABITANT_link = 80;
const int NGRAM_ETALON = 81;
const int CHILD_link = 82;
const int PARENT_link = 83;
const int UNIT_link = 84;
const int SET_link = 85;
const int TO_WEAKENED_link = 86;
const int SUBSTITUTION_link = 87;
const int VERBMODE_BASIC_link = 88;
const int NEGATION_PARTICLE_link = 89;
const int NEXT_COLLOCATION_ITEM_link = 90;
const int VIRTUAL_NODE_CONTENT_link = 91;
const int SUBORDINATE_CLAUSE_link = 92;
const int RIGHT_GENITIVE_OBJECT_link = 93;
const int ADV_PARTICIPLE_link = 94;
const int POSTFIX_PARTICLE_link = 95;
const int INFINITIVE_link = 96;
const int NEXT_ADJECTIVE_link = 97;
const int NEXT_NOUN_link = 98;
const int THEMA_link = 99;
const int RIGHT_PARTICLE_link = 100;
const int RIGHT_AUX2INFINITIVE_link = 101;
const int RIGHT_AUX2PARTICIPLE = 102;
const int RIGHT_AUX2ADJ = 103;
const int RIGHT_LOGIC_ITEM_link = 104;
const int RIGHT_COMPARISON_Y_link = 105;
const int RIGHT_NOUN_link = 106;
const int RIGHT_INSTR_OBJECT_link = 107;
const int RIGHT_DATIVE_OBJECT_link = 108;
const int RIGHT_NAME_link = 109;
const int ADJ_PARTICIPLE_link = 110;
const int RIGHT_ADJ_CLAUSE_link = 111;
const int PUNCTUATION_link = 112;
const int IMPERATIVE_SUBJECT_link = 113;
const int IMPERATIVE_VERB2AUX_link = 114;
const int AUX2IMPERATIVE_VERB = 115;
const int PREFIX_PARTICLE_link = 116;
const int ADRESS_TO_LISTENER_link = 117;
const int PREFIX_CONJUNCTION_link = 118;
const int LOGICAL_CONJUNCTION_link = 119;
const int NEXT_CLAUSE_link = 120;
const int LEFT_AUX_VERB_link = 121;
const int BEG_INTRO_link = 122;
const int RIGHT_PREPOSITION_link = 123;
const int WH_SUBJECT_link = 124;
const int IMPERATIVE_PARTICLE_link = 125;
const int GERUND_link = 126;
const int PREPOS_ADJUNCT_link = 127;
const int DIRECT_OBJ_INTENTION_link = 128;
const int COPULA_link = 129;
const int DETAILS_link = 130;
const int SENTENCE_CLOSER_link = 131;
const int OPINION_link = 132;
const int APPEAL_link = 133;
const int TERM_link = 134;
const int SPEECH_link = 135;
const int QUESTION_link = 136;
const int POLITENESS_link = 137;
