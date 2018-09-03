using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace primary
{

    public class power {
        private int mantissa;
        private int exponent;

        public power(int m, int e) {
            this.mantissa = m;
            this.exponent = e;
        }

        public int getMantissa() {
            return this.mantissa;
        }

        public int getExponent() {
            return this.exponent;
        }

    }

    public static class Primary
    {

        public class Number {
            private int PrimaryNumber;

            private Number() { }
            private Number(int theNumber) {
                this.PrimaryNumber = theNumber;
            }

            public int getNumber() {
                return this.PrimaryNumber;

            }

            private void setNumber(int theNumber) {
                this.PrimaryNumber = theNumber;
            }

            private static int generateRandom(int max) {
                int RandomNumber;
                Random r = new Random(max);

                RandomNumber = r.Next(3,max);

                return RandomNumber;
            }

            public static int Factorial(int number) {
                if (number == 1) {
                    return 1;
                     }
                else {
                    return number * Factorial(number - 1);
                }
            }

            public static int Euklides(int number1, int number2) {
                int lnko;

                if (number1 > number2) {
                    if (number1 % number2 == 0)
                    {
                        return number2;
                    }
                    else
                    {
                        number2 = number1 % number2;

                    }
                }
                else {
                    if (number2 % number1 == 0)
                    {
                        return number1;
                    }
                    else
                    {
                        number1 = number2 % number1;

                    }
                }
                lnko = Euklides(number1, number2);
                return lnko;
            }

            public class Test { 

                //Primtesztelo algoritmusok
            public Boolean Erastothenes(int number) {
                Boolean valid=false;
                if ((number > -3 && number < 3 ) || (number % 2 == 0 )) {
                    //0,1,2 nem prímszám 
                        return false;
                }

                    valid = Erastothenes(number, number + 1);
                    return valid;
            }


                public int Jacobi(int a, int n) {
                    int temp;
                    int j=1;
                    while (a != 0) {
                        while (a % 2 == 0) {
                            a = a / 2;
                            if (n % 8 == 3 || n % 8 == 5) { j = -j; }
                        }
                        temp = a;
                        a = n;
                        n = temp;
                        if (a % 4 == 3 && n % 4 == 3) { j = -j; }
                        a = a % n;
                    }
                    if (n == 1) { return j; } else { return 0; }
                }


                //Erasztothenész szitája, felső keresési korláttal



                public Boolean Erastothenes(int number, int maximum) {
                Boolean valid = false;


                bool[] nums = new bool[maximum];

                nums[0] = false;

                for (int i = 1; i < nums.Length; i++)
                {
                    nums[i] = true;
                }

                int p = 2;

                while (Math.Pow(p, 2) < maximum)
                {
                    if (nums[p])
                    {
                        int j = (int)Math.Pow(p, 2);

                        while (j < maximum)
                        {
                            nums[j] = false;
                            j = j + p;
                        }
                    }

                    p++;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if ((i+1)==number)
                    {
                        valid = nums[i];
                    }
                }


                return valid;
            }

                public Boolean Wilson(int number) {
                    /*
                     Ennek a prímtesztnek, legalábbis ma, csak elméleti jelentősége van (tehát gyakorlatilag semmi); a Wilson-tételen alapul:

                    Az n>1 szám csak akkor prím, ha n|(n-1)!+1. */
   
                    if ((number>1) && (number % (Primary.Number.Factorial(number - 1) + 1) == 0))   { return true; } else { return false; }

                }

                public Boolean Fermat(int number, int chance) {
                    int a;
                    int i;

                    if (number % 2 == 0) { return false; }
                    for (i = 0; i < chance; i++) {
                        a = Primary.Number.generateRandom(number);
                        while (Primary.Number.Euklides(number, a) != 1)
                        {
                            a = Primary.Number.generateRandom(number);
                        }
                        if ((a ^ (number - 1) % number) == 1) { break; }
                    }
                    if (i == chance) { return true; } else { return false; }
                }

                //Solovay–Strassen
                public Boolean SolovayStrassen(int number, int chance) {
                    int a;
                    int lnko;
                    int i;
                    for (i=0; i < chance; i++) { 
                        a = Primary.Number.generateRandom(number);
                        lnko = Primary.Number.Euklides(number, a);
                        if (lnko > 1) { break; }
                        if (Jacobi(a, number) == 0 || Math.Pow(a, (number - 1) / 2) % number != Jacobi(a, number)) {break; } 
                    }
                    if (i == chance) { return true; } else { return false; }
                        
                }
                /*
                 
                Egy adott páratlan n számról a következőképpen döntjük el, hogy prím-e: választunk véletlenszerűen egy 0<b<n egész számot. 
                Ezután kiszámítjuk az euklideszi algoritmus segítségével a (b, n) legnagyobb közös osztót.
                Ha ez egynél nagyobb, akkor készen vagyunk: n összetett szám. Ha nem, akkor kiszámítjuk egyrészt {\displaystyle b^{\frac {n-1}{2}}} {\displaystyle b^{\frac {n-1}{2}}} n-nel vett 
                legkisebb abszolút értékű maradékát, másrészt a : {\displaystyle \left({\frac {b}{n}}\right)} {\displaystyle \left({\frac {b}{n}}\right)} Jacobi-szimbólum értékét.
                Ha n prím, akkor a két értéknek, az Euler-kritérium értelmében, meg kell egyezni. Fontos megjegyezni, hogy noha a Jacobi-szimbólum n prímfelbontása segítségével van definiálva, 
                értéke anélkül is gyorsan kiszámítható. 
                Ha n összetett, akkor legfeljebb 1/2 annak a valószínűsége, hogy véletlen b-re ez a két érték megegyezik. 
                Ezért sokszor ismételjük a fenti próbát véletlenszerűen választott b értékekkel.
                Ha a két szám akár csak egyszer is eltér, akkor biztosak lehetünk benne, hogy n összetett. Ha viszont mindig megegyeznek, akkor igen nagy valószínűséggel prím.
                 */



                //Miller-Rabin

                public Boolean MillerRabin(int number)
                {
                    int exponent;
                    int remainder;
                    int a;
                    int b;

                    if (number % 2 != 0) { return false; }
                    remainder = number;
                    exponent = 0;
                    while (remainder % 2 == 0)
                    {
                        exponent += 1;
                        remainder = (int)(remainder / 2);
                    }

                    for (int i = 0; i > 100; i++)
                    {
                        a = generateRandom(number - 2);
                        b = ((int)Math.Pow(a, remainder) % number);
                        if (b != number - 1 && b != 1)
                        {

                        }
                        else { return false; }

                    }
                    return true;
                }

                /*
                Legyen n a tesztelendő páratlan szám, {\displaystyle n-1=2^{s
            }
            t
        } {\displaystyle n-1=2^{s
    }
    t
}, t páratlan.Legyen 0<b<n.

{\displaystyle b^{ t}\equiv 1{\pmod { n} } } {\displaystyle b^{t}\equiv 1{\pmod {n}}} 
vagy van olyan {\displaystyle 0\leq r<s} {\displaystyle 0\leq r<s}, hogy {\displaystyle b^{2^{r}t}\equiv -1{\pmod {n}}} {\displaystyle b^{2^{r}t}\equiv -1{\pmod {n}}}.
Ha n prímszám, akkor a fenti állítás minden b-re teljesül; ha n összetett, akkor ez legfeljebb a b-k egynegyedére igaz.Ezért véletlenszerűen választunk b értékeket, és ha mondjuk 100 
egymásutáni választásra igaz a fenti állítás, akkor n nagy valószínűséggel prím.


(Sokan félreértelmezik a fentieket, és úgy gondolják, hogy sok teszt szükséges.
Nem veszik figyelembe, hogy ha n összetett, ami nagyon ritkán fordul elő egy nagyobb, véletlenszerűen választott páratlan számnál - ha az átmegy a teszten.Pl. 2^64-ig 31894014 db (b= 2) 
álprím és 4,25656*10^17 prímszám van, tehát kevesebb, mint 2^(-32) valószínűséggel összetett - pedig csak egy teszt.)
*/

                //A BPSW-teszt

                /*

                 Kidolgozói, névadói: Robert Baillie, Carl Pomerance, John L. Selfridge, és Samuel S. Wagstaff, Jr.

Jelenleg (2013 július) a leghatékonyabb valószínűségi prímteszt: nem bizonyítja egy szám prím voltát, ha átmegy a teszten, de erősen valószínűsíti: P=99,9999...%. Ellenben bizonyítja az összetettségét, ha bukik rajta.

A BPSW-teszt két teszt kombinációja: egy Miller–Rabin-teszt (b=2, ld. előbb), és egy Lucas-Selfridge teszt. 

            Lucas Prímteszt:

            Let n be a positive integer. If there exists an integer a, 1 < a < n, such that

a^(n-1) kongruens 1(mod n)


and for every prime factor q of n − 1  //minden n-1 prímfaktorára


{\displaystyle a^{({n-1})/q}\ \not \equiv \ 1{\pmod {n}}\,} a^{{({n-1})/q}}\ \not \equiv \ 1{\pmod  n}\,
then n is prime. If no such number a exists, then n is either 1 or composite.





            Utóbbinak a lényege, hogy ha n osztója az első Lucas-sor n+1. elemének, - U[n+1] mod n = 0 - akkor n prím vagy Lucas-álprím.

A BPSW-teszt fő erejét az a tény adja, hogy a rész-teszteknek különböző típusú álprímjei vannak, melyeknek nincs eddig ismert közös eleme, tehát nem ismerünk még olyan összetett számot, amelyik átmenne mindkét teszten. Bizonyított, hogy 264-ig (kb.18 trillió) nincs BPSW-álprím.

Pomerance feltételezi, hogy végtelen sok álprímje van ennek a tesztnek is. Zhuo Chen és John Greene megadott egy 21248 (376 jegyű szám!) elemű számhalmazt, melyben 740 álprím is lehet.


                Input: n > 2, an odd integer to be tested for primality; k, a parameter that determines the accuracy of the test 
Output: prime if n is prime, otherwise composite or possibly composite;
determine the prime factors of n−1.
LOOP1: repeat k times:
   pick a randomly in the range [2, n − 1]()Ö
      if {\displaystyle a^{n-1}\not \equiv 1{\pmod {n}}} {\displaystyle a^{n-1}\not \equiv 1{\pmod {n}}} then
          return composite
      else # {\displaystyle \color {Gray}{a^{n-1}\equiv 1{\pmod {n}}}} {\displaystyle \color {Gray}{a^{n-1}\equiv 1{\pmod {n}}}}
         LOOP2: for all prime factors q of n−1:
            if {\displaystyle a^{\frac {n-1}{q}}\not \equiv 1{\pmod {n}}} {\displaystyle a^{\frac {n-1}{q}}\not \equiv 1{\pmod {n}}} then
               if we checked this equality for all prime factors of n−1 then
                  return prime
               else
                  continue LOOP2
            else # {\displaystyle \color {Gray}{a^{\frac {n-1}{q}}\equiv 1{\pmod {n}}}} {\displaystyle \color {Gray}{a^{\frac {n-1}{q}}\equiv 1{\pmod {n}}}}
               continue LOOP1
        return possibly composite.




                 */

                public static Boolean Lucas(int number) {
                    bool valid;
                    int a;
                    int q;
                    a = generateRandom(number - 1);
                    //loop 1
                    if ((a ^ (number - 1) % number) == 1) {
                        //loop2
                        // (n-1)-et prímtényezőkre bontjuk és annak vizsgáljuk a kongruenciáját
                        if ((a ^ ((number - 1)/q) % number) == 1)
                        {

                        }

                    else valid = false;

                }



                //AKS
                /*

                2002 augusztusában három indiai matematikus – Manindra Agrawal, Neeraj Kayal és Nitin Saxena – polinomiális prímtesztet talált ki. 
                Ez a prímek következő karakterizációján alapul: Legyen {\displaystyle n\geq 2} {\displaystyle n\geq 2} természetes szám, r olyan n-nél kisebb természetes szám, 
                hogy n rendje r-rel osztva nagyobb, mint ( {\displaystyle log_{10}} {\displaystyle log_{10}} n)2. n pontosan akkor prím, ha:

1. n nem teljes hatvány,
2. n-nek nincs prímtényezője, ami {\displaystyle \leq r} {\displaystyle \leq r},
3. {\displaystyle (x+a)^{n}\equiv x^{n}+a{\pmod {(n,x^{r}-1)}}} {\displaystyle (x+a)^{n}\equiv x^{n}+a{\pmod {(n,x^{r}-1)}}}teljesül minden {\displaystyle 1\leq a\leq {\sqrt {r}}\log n} {\displaystyle 1\leq a\leq {\sqrt {r}}\log n}egész számra. 

                 */



                //Euklidesz algoritmus
                /*
                 Az euklideszi algoritmus egymást követő lépései az előző lépés eredményéből indulnak ki. 
                 A lépéseket a k index számolja nullától kezdődően. Így a kezdőlépés a k = 0, a következő lépés a k = 1 indexet használja, és így tovább.

Minden lépés az rk−1 és rk−2 maradékokat használja. Mivel a maradékok folyamatosan csökkennek, azért rk−1 kisebb, mint rk−2. A cél az, hogy találjunk egy qk hányadost és egy rk maradékot, 
amellyel az

r_{k-2}=q_{k}r_{k-1}+r_{k}

egyenlőség teljesül. Szavakkal, a nagyobb rk−2 számból a kisebb rk−1 többszöröseit vonja le, amíg egy még kisebb rk számhoz nem jut.

A (k = 0) kezdőlépésben az r−2 és r−1 számok megfeleltethetők a kiindulási számoknak. 
A következő lépésben (k = 1) a kisebb kezdőszám és a nulladik lépésben kapott r0 maradékot használja, és így tovább. Így az algoritmus írható mint az

a&=q_{0}b+r_{0}\\
b&=q_{1}r_{0}+r_{1}\\
r_{0}&=q_{2}r_{1}+r_{2}\\
r_{1}&=q_{3}r_{2}+r_{3}

egyenlőségek sorozata.

Ha a kisebb szám az a, akkor az első lépésben az algoritmus felcseréli a számokat. 
Például, ha a < b, akkor az első q0 hányados nulla lesz, és a maradék r0 = a. 
Ettől kezdve az rk maradék mindig kisebb lesz, mint az előző rk−1 maradék minden k ≥ 0 indexre. 
Mivel a maradékok minden lépésben csökkennek, és sosem lehetnek negatívok, így előbb-utóbb lesz egy maradék, rN = 0[14] 
Az utolsó nem nulla maradék lesz a legnagyobb közös osztó. Az N nem lehet végtelen, mert csak véges sok egész van a nulla és az első r0 maradék között.
                 */


                //Carmichael-teszt


                //faktorizáció

                /*

                Egy egyszerű faktorizáló eljárás
Leírás
Az alábbiakban leírunk egy rekurzív eljárást számok prímtényezős felbontására: Adott egy n szám

ha n prím, készen vagyunk, megvan a prímtényezős felbontás.
ha n összetett, osszuk el n-t az első {\displaystyle p_{1}\,} {\displaystyle p_{1}\,} prímmel.
Ha az osztás maradék nélküli, kezdjük újra az algoritmust az {\displaystyle {\frac {n}{p_{1}}}} {\displaystyle {\frac {n}{p_{1}}}} értékkel, s adjuk hozzá {\displaystyle p_{1}\,} {\displaystyle p_{1}\,}-et az n prímtényezős listájához.
Ha az osztás maradékos volt, akkor osszuk n-t a következő {\displaystyle p_{2}\,} {\displaystyle p_{2}\,} prímmel, és így tovább, amíg az aktuális {\displaystyle {\frac {n}{p_{i}}}} {\displaystyle {\frac {n}{p_{i}}}} érték 1 nem lesz, maradék nélkül. Ekkor megállunk.
Megjegyezzük, hogy elég csupán azokkal a {\displaystyle p_{i}\,} {\displaystyle p_{i}\,} prímmekkel osztani n-t melyekre igaz, hogy {\displaystyle p_{i}\leq {\sqrt {n}}} {\displaystyle p_{i}\leq {\sqrt {n}}}. 


                 C programkod

                int main(void) {
    int t[100];
    unsigned long long j, i, k, d; //ha csak a pozitív számokat vesszük
    while (1==scanf("%llu", &k)) {
        if (k<0) k*=(-1);
        i=0;
        d=2;
        while (k>1) {
            if (k%d==0) {
                k/=d; 
                t[i]=d;
                i++;
            } else {
                ++d;
            }
        }
        for (j=0;j<i;j++) {
            printf("%d ", t[j]);
        }
        printf("\n\n");
    }
    return 0;
}


                 */


            }

        }
        public class Polinom {
                //polinom: soktagú összeg, pl. ax2+bx+c
        }

    }

}
