//DISABLED QUESTION RANDOMIZE FOR NOW.
//toimplement: if randomization is enabled, no repeated questions and auto test end when all questions are used.

#pragma once

#include <cstdlib>
#include <ctime>
#include <iostream>

namespace Teste_Conducao {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

#pragma region Items
	private: System::Windows::Forms::PictureBox^  pictureBox3;

	private: System::Windows::Forms::GroupBox^  groupBox1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::RadioButton^  op4;

	private: System::Windows::Forms::RadioButton^  op3;


	private: System::Windows::Forms::RadioButton^  op2;

	private: System::Windows::Forms::RadioButton^  op1;

	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::Button^  button4;


	private: System::ComponentModel::IContainer^  components;
	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>

		#pragma endregion

#pragma region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->pictureBox3 = (gcnew System::Windows::Forms::PictureBox());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->op4 = (gcnew System::Windows::Forms::RadioButton());
			this->op3 = (gcnew System::Windows::Forms::RadioButton());
			this->op2 = (gcnew System::Windows::Forms::RadioButton());
			this->op1 = (gcnew System::Windows::Forms::RadioButton());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox3))->BeginInit();
			this->groupBox1->SuspendLayout();
			this->SuspendLayout();
			// 
			// pictureBox3
			// 
			this->pictureBox3->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox3.Image")));
			this->pictureBox3->Location = System::Drawing::Point(255, 12);
			this->pictureBox3->Name = L"pictureBox3";
			this->pictureBox3->Size = System::Drawing::Size(194, 174);
			this->pictureBox3->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBox3->TabIndex = 2;
			this->pictureBox3->TabStop = false;
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->label1);
			this->groupBox1->Controls->Add(this->button2);
			this->groupBox1->Controls->Add(this->button1);
			this->groupBox1->Controls->Add(this->op4);
			this->groupBox1->Controls->Add(this->op3);
			this->groupBox1->Controls->Add(this->op2);
			this->groupBox1->Controls->Add(this->op1);
			this->groupBox1->Location = System::Drawing::Point(0, 452);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(630, 178);
			this->groupBox1->TabIndex = 4;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Teste de Código";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(21, 69);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(133, 13);
			this->label1->TabIndex = 6;
			this->label1->Text = L"O que significa este sinal \?";
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(515, 114);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(75, 50);
			this->button2->TabIndex = 5;
			this->button2->Text = L"Pular esta";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &Form1::button2_Click);
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(434, 115);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 50);
			this->button1->TabIndex = 4;
			this->button1->Text = L"OK";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// op4
			// 
			this->op4->AutoSize = true;
			this->op4->Location = System::Drawing::Point(196, 92);
			this->op4->Name = L"op4";
			this->op4->Size = System::Drawing::Size(104, 17);
			this->op4->TabIndex = 3;
			this->op4->TabStop = true;
			this->op4->Text = L"Obrigatório Parar";
			this->op4->UseVisualStyleBackColor = true;
			// 
			// op3
			// 
			this->op3->AutoSize = true;
			this->op3->Location = System::Drawing::Point(196, 69);
			this->op3->Name = L"op3";
			this->op3->Size = System::Drawing::Size(79, 17);
			this->op3->TabIndex = 2;
			this->op3->TabStop = true;
			this->op3->Text = L"Deve Parar";
			this->op3->UseVisualStyleBackColor = true;
			// 
			// op2
			// 
			this->op2->AutoSize = true;
			this->op2->Location = System::Drawing::Point(196, 46);
			this->op2->Name = L"op2";
			this->op2->Size = System::Drawing::Size(78, 17);
			this->op2->TabIndex = 1;
			this->op2->TabStop = true;
			this->op2->Text = L"Pode Parar";
			this->op2->UseVisualStyleBackColor = true;
			// 
			// op1
			// 
			this->op1->AutoSize = true;
			this->op1->Location = System::Drawing::Point(196, 23);
			this->op1->Name = L"op1";
			this->op1->Size = System::Drawing::Size(91, 17);
			this->op1->TabIndex = 0;
			this->op1->TabStop = true;
			this->op1->Text = L"Proibido Parar";
			this->op1->UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(40, 97);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(75, 62);
			this->button3->TabIndex = 7;
			this->button3->Text = L"Iniciar teste";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &Form1::button3_Click);
			// 
			// button4
			// 
			this->button4->Location = System::Drawing::Point(504, 97);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(75, 62);
			this->button4->TabIndex = 8;
			this->button4->Text = L"Terminar teste";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &Form1::button4_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Center;
			this->ClientSize = System::Drawing::Size(630, 628);
			this->Controls->Add(this->button4);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->groupBox1);
			this->Controls->Add(this->pictureBox3);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox3))->EndInit();
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion

#pragma region Variables
		int points; // score
		int rightans; // right answers count
		int wrongans; // wrong answers count
		int skippedquestions; // skipped questions count
		//int random; // used to randomize questions
		int totalquestions;
	    int qcount; // used for question switch
		System::String ^ correctans; // copys correct answer
		System::String ^ answerchosen; // compares chosen answer to correct one

#pragma endregion

#pragma region Buttons/Form Load

private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

				 if (op1->Checked) {
					 answerchosen = op1->Text;
				 }

				 if (op2->Checked) {
					 answerchosen = op2->Text;
				 }

				 if (op3->Checked) {
					 answerchosen = op3->Text;
				 }

				 if (op4->Checked) {
					 answerchosen = op4->Text;
				 }

				 if (correctans != answerchosen)
				 {
					 MessageBox::Show("Resposta errada. Perdeu 2 pontos.");
					 points -= 2;
					 wrongans += 1;
					 if (wrongans >=3)
					 {
						 button4->PerformClick();
					 }
					 //question();
				}
				 else {
					 MessageBox::Show("Resposta correcta. Ganhou 5 pontos.");
					 rightans += 1;
					 points += 5;
					 qcount += 1;
					 totalquestions += 1;
					 question();
				 }
			 }
private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
			 if (MessageBox::Show("Tem a certeza que quer saltar esta pergunta?" + Environment::NewLine + "Ira sofrer uma deducao de 3 pontos.", "Confirmação", MessageBoxButtons::YesNo, MessageBoxIcon::Question) == System::Windows::Forms::DialogResult::Yes)
			 {
				 points -= 3;
				 qcount += 1;
				 totalquestions += 1;
				 skippedquestions += 1;
				 question();
			 }
		 }
private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
			 op1->Enabled=false;
			 op2->Enabled=false;
			 op3->Enabled=false;
			 op4->Enabled=false;
			 button1->Enabled=false;
			 button2->Enabled=false;
			 button3->Enabled=true;
			 button4->Enabled=false;
			 label1->Text="À espera que inicie o teste.";
			 op1->Text="";
			 op2->Text="";
			 op3->Text="";
			 op4->Text="";
			 qcount = 1; // forces program to be on 1st question when loaded.
		 }
private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {

			 // used to restart exam (no randomization).
			 if (totalquestions > 0) {
				 points = 0;
				 rightans = 0;
				 wrongans = 0;
				 skippedquestions = 0; 
				 qcount = 1;
				 totalquestions = 0;
			 }
			 // end comment

			 op1->Enabled=true;
			 op2->Enabled=true;
			 op3->Enabled=true;
			 op4->Enabled=true;
			 button1->Enabled=true;
			 button2->Enabled=true;
			 button3->Enabled=false;
			 button4->Enabled=true;
			 points = 0;
			 MessageBox::Show("Apenas pode errar 3 perguntas, o seu teste irá começar, boa sorte.");
			 question();
		 }
private: System::Void button4_Click(System::Object^  sender, System::EventArgs^  e) {
			 
			 op1->Enabled=false;
			 op2->Enabled=false;
			 op3->Enabled=false;
			 op4->Enabled=false;
			 button1->Enabled=false;
			 button2->Enabled=false;
			 button3->Enabled=true;
			 button4->Enabled=false;
			 pictureBox3->ImageLocation="E:\\Backup M2\\RC\\C++\\Teste_Conducao\\ponto-interrogacao.jpg";
			 op1->Text="";
			 op2->Text="";
			 op3->Text="";
			 op4->Text="";
			 label1->Text="Teste concluido.";
			 MessageBox::Show("O seu teste terminou." + Environment::NewLine + "Obteve a seguinte pontuacao: " + points + Environment::NewLine + "Respostas certas: " + rightans + Environment::NewLine + "Respostas erradas: " + wrongans + Environment::NewLine + "Perguntas puladas: " + skippedquestions);
			 
			 if (totalquestions >= 0) {
				pointshandle();
			 }

		points = 0;
		rightans = 0;
		wrongans = 0;
		skippedquestions = 0; 
		//qcount = 1;
		//totalquestions = 0;

		 }
#pragma endregion

#pragma region Points handling
		 void pointshandle() {
			 	    if (points <= 0)
		{
		MessageBox::Show("Chumbou no teste, pense em estudar.");
		}
		
		if (points >= 1 && points <=5)
		{
			MessageBox::Show("Passou no teste a rasca.");
		}
		
		if (points > 5 && points <= 9)
		{
			MessageBox::Show("Passou com uma nota minimamente decente.");
		}

		if (points > 10)
		{
			MessageBox::Show("Passou com uma nota decente.");
		}
		 }
#pragma endregion

#pragma region Question handling

		 void question() {

			 //random = (rand() % 3) + 1;

			 //if (qcount == random) {
				// do 
				// {
				//	 random = (rand() % 3) + 1;
				// } while (random == qcount);
			 //}

			//qcount = random; // passes random value to qcount and goes to the specified question.
			 
			 op1->Checked=false;
			 op2->Checked=false;
			 op3->Checked=false;
			 op4->Checked=false;

			 if (totalquestions >=3)
			 {
				 button4->PerformClick();
			 }

			 switch (qcount) {
			 case 1:
				 label1->Text="O que significa este sinal?";
				 op1->Text="Continuar a andar.";
				 op2->Text="Talvez parar.";
				 op3->Text="Devo parar.";
				 op4->Text="Obrigatorio parar."; //correct
				 pictureBox3->ImageLocation="E:\\Backup M2\\RC\\C++\\Teste_Conducao\\stop.jpg";
				 correctans = op4->Text;
				 break;
			 case 2:
				 label1->Text="O que significa este sinal?";
				 op1->Text="Fazer o que esta la indicado a grande e a francesa.";
				 op2->Text="Proibido fazer inversao de marcha."; //correct
				 op3->Text="Ficar indignado com a situacao";
				 op4->Text="Dar meia-volta assim pela surra."; 
				 correctans = op2->Text;
				 pictureBox3->ImageLocation="E:\\Backup M2\\RC\\C++\\Teste_Conducao\\prod_img_0740145001336982679_41410.jpg";
				 break;
			 case 3:
				 label1->Text="O que significa este sinal?";
			     op1->Text="Obrigatorio virar a esquerda."; //correct
				 op2->Text="Seguir em frente e cair numa vala.";
				 op3->Text="Complementar o belo visual do sinal like a sir.";
				 op4->Text="Ir para a direita que nem um patrao.";
				 pictureBox3->ImageLocation="E:\\Backup M2\\RC\\C++\\Teste_Conducao\\virar-esquerda.jpg";
				 correctans = op1->Text;
				 break;
			 default: break;//MessageBox::Show("Exception: No more questions available.");
			 }
		 }
#pragma endregion

};
}

