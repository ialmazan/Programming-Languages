/*
Ivan Almazan
Id# 759511
Seth Hochwald
CS 37 Tues & Thurs 11-12:20pm
*/

#include<iostream>
#include<string>
//#include<iomanip>
using namespace std;

class Bet
{
public:
	Bet(const char * =" ", const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0);
	virtual double calcBonus()const=0;
	virtual void print()const=0;
	char *bettype, *team1, *team2, *betton;
	float score1, score2, betamount;
};

Bet::Bet(const char *type, const char *t1, float s1, const char *t2, float s2, const char *bett, float bamt)
{
	bettype = new char[strlen(type)+1];
	strcpy(bettype,type);
	betton = new char[strlen(bett)+1];
	strcpy(betton,bett);
	team1 = new char[strlen(t1)+1];
	strcpy(team1,t1);
	team2 = new char[strlen(t2)+1];
	strcpy(team2,t2);
	score1 = s1;
	score2 = s2;
	betamount = bamt;
}

class Winner:public Bet
{
public:
	Winner(const char * =" ", const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0, float =0.0);
	virtual double calcBonus()const;
	virtual void print()const;
private:
	float wins;
};

Winner::Winner(const char *type, const char *t1, float s1, const char *t2, float s2, const char *bett, float bamt, float won)
:Bet(type,t1,s1,t2,s2,bett,bamt)
{
	wins=won;

	if(bett==t1 && s1>s2)
		wins = bamt * 0.9;
	else
		if(bett==t2 && s2>s1)
			wins = bamt * 0.9;
		else
			wins = 0;
}

double Winner::calcBonus()const
{
	if(wins<=200)
		return wins + (wins * 0.005);
	else
		if(wins<=1500)
			return wins + (wins * 0.01);
		else
			if(wins<=7500)
				return wins + (wins * 0.015);
			else
				return wins + (wins * 0.02);
}

void Winner::print()const
{
	cout<<bettype<<endl;
	cout<<"Game Results {"<<team1<<":"<<score1<<' '<<team2<<":"<<score2<<'}'<<endl;
	cout<<"Bet on the: "<<betton<<" for: "<<betamount<<endl;
	cout<<"Amount won is: $"<<wins<<" and with bonus amount won is: $";
}

class PointSpread:public Bet
{
public:
	PointSpread(const char * =" ", const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0, float =0.0, float =0.0);
	virtual double calcBonus()const;
	virtual void print()const;
private:
	float spread,wins;
};

PointSpread::PointSpread(const char *type, const char *t1, float s1, const char *t2, float s2, const char *bett, float bamt, float s, float won)
:Bet(type,t1,s1,t2,s2,bett,bamt)
{
	wins=won;
	spread=s;

	if(bett==t1 && s1>s2+spread)
		wins = bamt * 0.95;
	else
		if(bett==t1 && s1<=s2+spread)
			wins = 0;
		else
			if(s2+spread==s1)
				wins = 0;
			else
				if(-spread<s2+spread-s1 && s2+spread-s1<spread)
					wins = bamt * 0.95;
				else
					if(s2+spread-s1==spread)
						wins = bamt;
					else
						wins = 0;
}

double PointSpread::calcBonus()const
{
	if(wins==betamount)
		return betamount;
	else
		if(wins<=200)
			return wins + (wins * 0.005);
		else
			if(wins<=1500)
				return wins + (wins * 0.01);
			else
				if(wins<=7500)
					return wins + (wins * 0.015);
				else
					return wins + (wins * 0.02);
}

void PointSpread::print()const
{
	cout<<bettype<<endl;
	cout<<"Game Results {"<<team1<<":"<<score1<<' '<<team2<<":"<<score2<<'}'<<endl;
	cout<<"Bet on the: "<<betton<<" with a spread of "<<spread<<" for: "<<betamount<<endl;
	cout<<"Amount won is: $"<<wins<<" and with bonus amount won is: $";
}

class OverUnder:public Bet
{
public:
	OverUnder(const char * =" ", const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0, float =0.0, float =0.0);
	virtual double calcBonus()const;
	virtual void print()const;
private:
	float total,wins;
};

OverUnder::OverUnder(const char *type, const char *t1, float s1, const char *t2, float s2, const char *bett, float bamt, float t, float won)
:Bet(type,t1,s1,t2,s2,bett,bamt)
{
	total = t;
	wins = won;

	if(bett=="Over" && s1+s2>total)
		wins = bamt * 0.85;
	else
		if(bett=="Under" && s1+s2<total)
			wins = bamt * 0.85;
		else
			if(s1+s2==total)
				wins = bamt;
			else
				wins = 0;
}

double OverUnder::calcBonus()const
{
	if(wins==betamount)
		return betamount;
	else
		if(wins<=200)
			return wins + (wins * 0.005);
		else
			if(wins<=1500)
				return wins + (wins * 0.01);
			else
				if(wins<=7500)
					return wins + (wins * 0.015);
				else
					return wins + (wins * 0.02);
}

void OverUnder::print()const
{
	cout<<bettype<<endl;
	cout<<"Game Results {"<<team1<<":"<<score1<<' '<<team2<<":"<<score2<<'}'<<endl;
	cout<<"Bet "<<betton<<" the estimated total points of: "<<total<<" for: $"<<betamount<<endl;
	cout<<"Amount won is: $"<<wins<<" and with bonus amount won is: $";
}

class TwoTeam:public Bet
{
public:
	TwoTeam(const char * =" ", const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0, const char * =" ", float =0.0);
	virtual double calcBonus()const;
	virtual void print()const;
private:
	char *team3,*team4,*betton2;
	float score3,score4,wins;
};

TwoTeam::TwoTeam(const char *type, const char *t1, float s1, const char *t2, float s2, const char *bett, float bamt, const char *t3, float s3, const char *t4, float s4, const char *bett2, float won)
:Bet(type,t1,s1,t2,s2,bett,bamt)
{
	betton2 = new char[strlen(bett2)+1];
	strcpy(betton2,bett2);
	team3 = new char[strlen(t3)+1];
	strcpy(team3,t3);
	team4 = new char[strlen(t4)+1];
	strcpy(team4,t4);
	score3 = s3;
	score4 = s4;
	wins = won;

	if((bett==t1 && s1>s2)&&(bett2==t3 && s3>s4))
		wins = bamt;
	else
		if((bett==t1 && s1>s2)&&(bett2==t4 && s4>s3))
			wins = bamt;
		else
			if((bett==t2 && s2>s1)&&(bett2==t3 && s3>s4))
				wins = bamt;
			else
				if((bett==t2 && s2>s1)&&(bett2==t4 && s4>s3))
					wins = bamt;
				else
					wins = 0;
}

double TwoTeam::calcBonus()const
{
	if(wins<=200)
		return wins + (wins * 0.005);
	else
		if(wins<=1500)
			return wins + (wins * 0.01);
		else
			if(wins<=7500)
				return wins + (wins * 0.015);
			else
				return wins + (wins * 0.02);
}

void TwoTeam::print()const
{
	cout<<bettype<<endl;
	cout<<"Game Results: Game 1{"<<team1<<":"<<score1<<' '<<team2<<":"<<score2<<"} Game 2{"<<team3<<":"<<score3<<' '<<team4<<":"<<score4<<'}'<<endl;
	cout<<"Bet on the: "<<betton<<" and "<<betton2<<" for: $"<<betamount<<endl;
	cout<<"Amount won is: $"<<wins<<" and with bonus amount won is: $";
}

int main()
{
	//cout << fixed << showpoint << setprecision(2);
	Winner w("WINNER BET","Lakers",90,"Clippers",76,"Lakers",100);
	w.print();
	cout<<w.calcBonus();
	cout<<endl<<endl;
	PointSpread p("POINT SPREAD BET","Bulls",86,"Heat",85,"Heat",1600,10);
	p.print();
	cout<<p.calcBonus();
	cout<<endl<<endl;
	OverUnder ou("OVER UNDER BET","Nicks",54,"Magic",78,"Over",700,120);
	ou.print();
	cout<<ou.calcBonus();
	cout<<endl<<endl;
	TwoTeam tt("TWO TEAM PARLAY","Bucks",66,"Wizards",45,"Bucks",10000,"Hawks",13,"Suns",45,"Suns");
	tt.print();
	cout<<tt.calcBonus();
	cout<<endl<<endl;
	return 0;
}
/*
WINNER BET
Game Results {Lakers:90 Clippers:76}
Bet on the: Lakers for: 100
Amount won is: $90 and with bonus amount won is: $90.45

POINT SPREAD BET
Game Results {Bulls:86 Heat:85}
Bet on the: Heat with a spread of 10 for: 1600
Amount won is: $1520 and with bonus amount won is: $1542.8

OVER UNDER BET
Game Results {Nicks:54 Magic:78}
Bet Over the estimated total points of: 120 for: $700
Amount won is: $595 and with bonus amount won is: $600.95

TWO TEAM PARLAY
Game Results: Game 1{Bucks:66 Wizards:45} Game 2{Hawks:13 Suns:45}
Bet on the: Bucks and Suns for: $10000
Amount won is: $10000 and with bonus amount won is: $10200

Press any key to continue . . .
*/