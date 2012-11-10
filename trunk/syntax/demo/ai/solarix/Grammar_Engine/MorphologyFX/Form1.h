#pragma once

#using <mscorlib.dll>
#using <System.DLL>
#using <System.Windows.Forms.DLL>
#using <System.Data.DLL>
#using <System.Drawing.dll>
#using <System.XML.DLL>

#using "../../../../../lib/gren_fx.dll"

using namespace SolarixGrammarEngineNET;

namespace MorphologyFX
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

	/// <summary> 
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the 
	///          'Resource File Name' property for the managed resource compiler tool 
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public __gc class Form1 : public System::Windows::Forms::Form
	{	
     private:
      //SolarixGrammarEngineNET::GrammarEngine *engine;
      System::IntPtr hEngine;

	public:
		Form1(void)
		{
         InitializeComponent();
         hEngine = NULL;
      
         if( System::IO::File::Exists( S"..\\..\\..\\..\\..\\bin-windows\\dictionary.xml" ) )
          ed_dictionarypath->Text = S"..\\..\\..\\..\\..\\bin-windows\\dictionary.xml";
         else if( System::IO::File::Exists( S"..\\..\\..\\..\\..\\dictionary.xml" ) )
          ed_dictionarypath->Text = S"..\\..\\..\\..\\..\\dictionary.xml";
         else if( System::IO::File::Exists( S"dictionary.xml" ) )
          ed_dictionarypath->Text = S"dictionary.xml";
		}
  
	protected:
		void Dispose(Boolean disposing)
		{
			if (disposing && components)
			{
				components->Dispose();
			}
			__super::Dispose(disposing);
		}

    private: System::Windows::Forms::Button *  cb_load;
    private: System::Windows::Forms::TextBox *  ed_dictionarypath;
    private: System::Windows::Forms::GroupBox *  groupBox1;

    private: System::Windows::Forms::Label *  label1;

    private: System::Windows::Forms::GroupBox *  groupBox2;
    private: System::Windows::Forms::Label *  label2;
    private: System::Windows::Forms::Label *  label3;

    private: System::Windows::Forms::TextBox *  ed_entrycount;
    private: System::Windows::Forms::TextBox *  ed_word;
    private: System::Windows::Forms::Button *  cb_analyze;
    private: System::Windows::Forms::ListBox *  lbx_wordforms;
    private: System::Windows::Forms::TextBox *  ed_formcount;
    private: System::Windows::Forms::Label *  label4;


	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container * components;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
            this->cb_load = new System::Windows::Forms::Button();
            this->ed_dictionarypath = new System::Windows::Forms::TextBox();
            this->groupBox1 = new System::Windows::Forms::GroupBox();
            this->lbx_wordforms = new System::Windows::Forms::ListBox();
            this->cb_analyze = new System::Windows::Forms::Button();
            this->label1 = new System::Windows::Forms::Label();
            this->ed_word = new System::Windows::Forms::TextBox();
            this->groupBox2 = new System::Windows::Forms::GroupBox();
            this->ed_entrycount = new System::Windows::Forms::TextBox();
            this->ed_formcount = new System::Windows::Forms::TextBox();
            this->label3 = new System::Windows::Forms::Label();
            this->label2 = new System::Windows::Forms::Label();
            this->label4 = new System::Windows::Forms::Label();
            this->groupBox1->SuspendLayout();
            this->groupBox2->SuspendLayout();
            this->SuspendLayout();
            // 
            // cb_load
            // 
            this->cb_load->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right);
            this->cb_load->Location = System::Drawing::Point(480, 16);
            this->cb_load->Name = S"cb_load";
            this->cb_load->Size = System::Drawing::Size(64, 23);
            this->cb_load->TabIndex = 0;
            this->cb_load->Text = S"Load";
            this->cb_load->Click += new System::EventHandler(this, cb_load_Click);
            // 
            // ed_dictionarypath
            // 
            this->ed_dictionarypath->Anchor = (System::Windows::Forms::AnchorStyles)((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right);
            this->ed_dictionarypath->Location = System::Drawing::Point(96, 16);
            this->ed_dictionarypath->Name = S"ed_dictionarypath";
            this->ed_dictionarypath->Size = System::Drawing::Size(376, 20);
            this->ed_dictionarypath->TabIndex = 1;
            this->ed_dictionarypath->Text = S"..\\..\\..\\..\\..\\bin-windows\\dictionary.xml";
            // 
            // groupBox1
            // 
            this->groupBox1->Anchor = (System::Windows::Forms::AnchorStyles)(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) 
                | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right);
            this->groupBox1->Controls->Add(this->lbx_wordforms);
            this->groupBox1->Controls->Add(this->cb_analyze);
            this->groupBox1->Controls->Add(this->label1);
            this->groupBox1->Controls->Add(this->ed_word);
            this->groupBox1->Location = System::Drawing::Point(8, 176);
            this->groupBox1->Name = S"groupBox1";
            this->groupBox1->Size = System::Drawing::Size(544, 272);
            this->groupBox1->TabIndex = 2;
            this->groupBox1->TabStop = false;
            this->groupBox1->Text = S"Morphology analysis";
            // 
            // lbx_wordforms
            // 
            this->lbx_wordforms->Anchor = (System::Windows::Forms::AnchorStyles)(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) 
                | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right);
            this->lbx_wordforms->Location = System::Drawing::Point(8, 64);
            this->lbx_wordforms->Name = S"lbx_wordforms";
            this->lbx_wordforms->Size = System::Drawing::Size(528, 199);
            this->lbx_wordforms->TabIndex = 3;
            // 
            // cb_analyze
            // 
            this->cb_analyze->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right);
            this->cb_analyze->Location = System::Drawing::Point(472, 24);
            this->cb_analyze->Name = S"cb_analyze";
            this->cb_analyze->Size = System::Drawing::Size(64, 23);
            this->cb_analyze->TabIndex = 2;
            this->cb_analyze->Text = S"Analyze";
            this->cb_analyze->Click += new System::EventHandler(this, cb_analyze_Click);
            // 
            // label1
            // 
            this->label1->Location = System::Drawing::Point(8, 24);
            this->label1->Name = S"label1";
            this->label1->Size = System::Drawing::Size(88, 23);
            this->label1->TabIndex = 1;
            this->label1->Text = S"Word:";
            // 
            // ed_word
            // 
            this->ed_word->Anchor = (System::Windows::Forms::AnchorStyles)((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right);
            this->ed_word->Location = System::Drawing::Point(104, 24);
            this->ed_word->Name = S"ed_word";
            this->ed_word->Size = System::Drawing::Size(360, 20);
            this->ed_word->TabIndex = 0;
            this->ed_word->Text = S"galaxy";
            // 
            // groupBox2
            // 
            this->groupBox2->Anchor = (System::Windows::Forms::AnchorStyles)((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right);
            this->groupBox2->Controls->Add(this->ed_entrycount);
            this->groupBox2->Controls->Add(this->ed_formcount);
            this->groupBox2->Controls->Add(this->label3);
            this->groupBox2->Controls->Add(this->label2);
            this->groupBox2->Location = System::Drawing::Point(8, 48);
            this->groupBox2->Name = S"groupBox2";
            this->groupBox2->Size = System::Drawing::Size(544, 104);
            this->groupBox2->TabIndex = 3;
            this->groupBox2->TabStop = false;
            this->groupBox2->Text = S"Dictionary status";
            // 
            // ed_entrycount
            // 
            this->ed_entrycount->Location = System::Drawing::Point(136, 24);
            this->ed_entrycount->Name = S"ed_entrycount";
            this->ed_entrycount->ReadOnly = true;
            this->ed_entrycount->TabIndex = 3;
            this->ed_entrycount->Text = S"";
            // 
            // ed_formcount
            // 
            this->ed_formcount->Location = System::Drawing::Point(136, 56);
            this->ed_formcount->Name = S"ed_formcount";
            this->ed_formcount->ReadOnly = true;
            this->ed_formcount->TabIndex = 2;
            this->ed_formcount->Text = S"";
            // 
            // label3
            // 
            this->label3->Location = System::Drawing::Point(8, 24);
            this->label3->Name = S"label3";
            this->label3->TabIndex = 1;
            this->label3->Text = S"Number of entries:";
            // 
            // label2
            // 
            this->label2->Location = System::Drawing::Point(8, 56);
            this->label2->Name = S"label2";
            this->label2->Size = System::Drawing::Size(120, 23);
            this->label2->TabIndex = 0;
            this->label2->Text = S"Number of wordforms:";
            // 
            // label4
            // 
            this->label4->AutoSize = true;
            this->label4->Location = System::Drawing::Point(8, 16);
            this->label4->Name = S"label4";
            this->label4->Size = System::Drawing::Size(83, 16);
            this->label4->TabIndex = 4;
            this->label4->Text = S"Dictionary path:";
            // 
            // Form1
            // 
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(560, 454);
            this->Controls->Add(this->label4);
            this->Controls->Add(this->ed_dictionarypath);
            this->Controls->Add(this->groupBox2);
            this->Controls->Add(this->groupBox1);
            this->Controls->Add(this->cb_load);
            this->Name = S"Form1";
            this->Text = S"Form1";
            this->groupBox1->ResumeLayout(false);
            this->groupBox2->ResumeLayout(false);
            this->ResumeLayout(false);

        }	

    private: System::Void cb_load_Click(System::Object *  sender, System::EventArgs *  e)
             { 
              System::String *path = ed_dictionarypath->Text;
              if( path->Length>0 )
               {
                hEngine = SolarixGrammarEngineNET::GrammarEngine::sol_CreateGrammarEngineW(path);
                if( hEngine!=NULL )
                 {
                  int nentry = SolarixGrammarEngineNET::GrammarEngine::sol_CountEntries(hEngine);
                  int nform = SolarixGrammarEngineNET::GrammarEngine::sol_CountForms(hEngine);
                  
                  ed_entrycount->Text = Convert::ToString(nentry);
                  ed_formcount->Text = Convert::ToString(nform);
                 }
               } 
             }
private: System::Void cb_analyze_Click(System::Object *  sender, System::EventArgs *  e)
         {
          System::String *word = ed_word->Text;
          if( word->Length>0 && hEngine!=NULL )
           {
            lbx_wordforms->Items->Clear();
            System::IntPtr hForms = GrammarEngine::sol_FindStringsEx( hEngine, word, true, false, false, false, false, 1 );
            int count = GrammarEngine::sol_CountStrings(hForms); 

            for( int i=0; i<count; i++ )
             {
              System::Text::StringBuilder *buf = new System::Text::StringBuilder(64);
              GrammarEngine::sol_GetStringW(hForms,i,buf); 
              lbx_wordforms->Items->Add( buf->ToString() );
             }

            GrammarEngine::sol_DeleteStrings(hForms);
           } 
         }

};
}


