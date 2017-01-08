#include <iostream>
#include<sstream>
#include<string>
#include<math.h>

//ivan almazan
//912383996

using namespace std;

union b
{
	float fbin;
	int exp;
};

int main()
{
	b thing;
	string exponent = "";
	string mantissa = "";
	int counter = 0;
	bool removeTrailing = true;
	cout << "Please enter a float: ";
	cin >> thing.fbin;
	if (thing.fbin == 0)
		cout << "0E0";
	else{
	if (thing.fbin > 0)
		cout << "1.";
	else
		cout << "-1.";

	for(int i=22;i>=0;i--)
		{
		if((thing.exp & (1 << i)))
			mantissa += "1";
		else
			mantissa += "0";
		}

	for(int i=30; i >= 23; i--)
	{
		if((thing.exp & (1 << i)))
		{
			exponent += "1";
		}
		else
		{
			exponent += "0";
		}
	}

	int power = exponent.length() - 1;
	int baseTen = 0;

	for (unsigned int i = mantissa.length(); i > 0; i--) //remove trailing zeros
	{
		if(mantissa[i-1] == '0' && removeTrailing == true)
		{
		}
		else
		{	
			removeTrailing = false;
			cout<<mantissa[counter];
			counter++;
		}
	}

	for (unsigned int i = 0; i < exponent.length(); i++)
	{
		int digit = exponent[i] - '0';
		baseTen += digit * pow(2, power);
		power--;
	}
	cout << "E" << baseTen - 127;}
	cout << endl;
}
