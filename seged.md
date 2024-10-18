# Programozási tételek

Segédanyag az ***IK-19fszPAEG** (2024/25/1)* [ELTE](https://www.inf.elte.hu/) tantárgyához.
[Specifikáció Készítő](https://progalapfsz.elte.hu/specifikacio/)
[C# leírás angol nyelven (tutorialspoint)](https://www.tutorialspoint.com/csharp/index.htm)

*Forrás: órai anyag*

`Megjegyzés: A specifikációban illetve a pszeudokódban az indexelés 1-től kezdödik (ez nem kötelező) a kódban a nyelvhez hűen 0-tól.`
`- A specifikációban sok helyen lehetet volna elő feltételt adni, de algoritmus szempontjából ez lényegtelen. Feladat megoldás szempontjából viszont sokszor nagyon is lényeges.`
                                                                    
>## Tartalom
>
>- [Alapvető proramozási tételek](#alapvető-programozási-tételek)
>    - [Összegzés](#összegzés)
>    - [Megszámolás](#megszámolás)
>    - [Maximum kiválasztás](#maximum-kiválasztás)
>        - [Minimum kiválasztás](#minimum-kiválasztás)
>    - [Feltételes maximum keresés](#feltételes-maximum-keresés)
>    - [Keresés](#keresés)
>    - [Eldöntés](#eldöntés)
>       - [Mind eldöntés](#mind-eldöntés)
>    - [Kiválasztás](#kiválasztás)
>    - [Másolás](#másolás)
>    - [Kiválogatás](#kiválogatás)

---

## Alapvető programozási tételek

### Összegzés

Ezt az algoritmust akkor alkalmazzuk, amikor több elem összegét szeretnénk meghatározni.

**Példa:** Hány gyerek jár egy iskolában, ha tudjuk az osztályok létszámát?

>**Specifikáció**
>```
>Be: db∈N, osztalyok∈N[1..db]
>Ki: osszesdiak∈N
>Ef: db > 1
>Uf: osszesdiak = SUM(i=1..db,osztalyok[i])
>```

>**Pszeudokód**
>```
>i:Egész
>Be: osztalyok[db]
>osszesdiak = 0
>Ciklus i = 1 -től db-ig
>    osszesdiak = osszesdiak + osztalyok[i]
>Ciklus vége
>Ki: osszesdiak
>```

>**Visszavezetés**
>```
>össz        ~   osszesdiak
>1..elemszám ~   1..db
>elemek[i]   ~   osztalyok[i] 
>```

>**C# algoritmus**
>```csharp
>int ossz = 0;
>for(int i = 0; i < elemek.Length; i++)
>{
>    ossz += elemek[i];
>}
>return ossz;
>```
---

### Megszámolás

Ezt az algoritmust akkor alkalmazzuk, amikor össze szeretnénk gyűjteni hány darab valamilyen(T) tulajdonságú elem van például egy tömbben.

**Példa:** Hányszor fagyott a hőmérsékleti adatok alapján?


>**Specifikáció**
>```
>Be: db∈N, homersekletiAdatok∈N[1..db]
>Ki: fagyottNapok∈N
>Ef: -
>Uf: fagyottNapok = DARAB(i=1..db,homersekletiAdatok[i] < 0)
>```

>**Pszeudokód**
>```
>i:Egész
>Be: homersekletiAdatok[db]
>fagyottNapok = 0
>Ciklus i = 1 -től db-ig
>    Ha (homersekletiAdatok[i] < 0) akkor
>        fagyott = fagyott + 1
>    Elágazás vége
>Ciklus vége
>Ki: fagyottNapok
>```

>**Visszavezetés**
>```
>1..elemszám    ~   1..db
>T(elemek[i])   ~   homersekletiAdatok[i] < 0
>```

>**C# algoritmus**
>```csharp
>int darab = 0;
>for (int i = 0; i < elemek.Length; i++)
>{
>    if (elemek[i] < 0)
>    {
>        darab++;
>    }
>}
>return darab;
>```
---

### Maximum kiválasztás
Gyakran kell a maximum illetve minimum érték programozás során, ezekkel az algoritmusokkal tudjuk megtalálni őket. A maximum és minimum kiválasztás között csak a logikai feltétel a különbség. Néha az index-re (a tömbnek a hányadik elemére), néha pedig az értékére vagy mindkettőre, algoritmuson nem változtat csak a kimeneten.

**Példa:** Ki a legmagasabb/legalacsonyabb a sorban?


>**Specifikáció**
>```
>Be: db∈N, magassagok∈N[1..db]
>Ki: maxind∈Z,legmagasabb∈H
>Ef: -
>Uf: (maxind,maxért)=MAX(i=1..elemszám, elemek[i]) 
>```

>**Pszeudokód**
>```
>i:Egész
>Be: magassagok[db]
>legmagasabbind = 1
>legmagasabbertek = magassagok[1]
>Ciklus i = 2 -től db-ig
>    Ha (magassagok[i] > legmagasabb) akkor
>        legmagasabbind = i
>        legmagasabbertek = magassagok[i]
>    Elágazás vége
>Ciklus vége
>Ki: legmagasabbind, legmagasabbertek
>```

>**Visszavezetés**
>```
>maxind, maxért ~   legmagasabbind,legmagasabbertek
>1..elemszám    ~   1..db
>elemek[i]      ~   magassagok[i]
>```

>**C# algoritmus**
>```csharp
>int maxIndex = 0;
>int maxErtek = elemek[0];
>for (int i = 1; i < elemek.Length; i++)
>{
>    if (elemek[i] > maxErtek)
>    {
>        maxIndex = i;
>        maxErtek = elemek[i];
>    }
>}
>return new int[] { maxIndex, maxErtek };
>```

#### Minimum kiválasztás

>**Specifikáció**
>```
>Be: db∈N, magassagok∈N[1..db]
>Ki: minind∈Z,legalacsonyabb∈H
>Ef: -
>Uf: (minind,minért)=MIN(i=1..elemszám, elemek[i]) 
>```

>**Pszeudokód**
>```
>i:Egész
>Be: magassagok[db]
>legalacsonyabbind = 1
>legalacsonyabbertek = magassagok[1]
>Ciklus i = 2 -től db-ig
>    Ha (magassagok[i] < legalacsonyabb) akkor
>        legalacsonyabbind = i
>        llegalacsonyabbertek = magassagok[i]
>    Elágazás vége
>Ciklus vége
>Ki: legalacsonyabbind, legalacsonyabbertek
>```

>**Visszavezetés**
>```
>minind, minért ~   legalacsonyabbind,legalacsonyabbertek
>1..elemszám    ~   1..db
>elemek[i]      ~   magassagok[i]
>```

>**C# algoritmus**
>```csharp
>int minIndex = 0;
>int minErtek = elemek[0];
>for (int i = 1; i < elemek.Length; i++)
>{
>    if (elemek[i] > minErtek)
>    {
>        minIndex = i;
>        minErtek = elemek[i];
>    }
>}
>return new int[] { minIndex, minErtek };
>```
---

### Feltételes maximum keresés

Ez az algoritmus gyakorlatilag a keresés illetve maximum kiválasztás kombinációja.
**Példa:** Például adjuk meg a legmelegebb fagyos napot.

>**Specifikáció**
>```
>Be: db∈N, homersekletek∈N[1..db]
>Ki: van∈L,maxind∈N,maxert∈N
>Ef: -
>Uf: (van,maxind,maxert)=MAXHA(i=1..db,homersekletek[i],(homersekletek[i]) < 0)
>```

>**Pszeudokód**
>```
>i:Egész
>Be: homersekletek[db]
>van = hamis
>Ciklus i = 1 -től db-ig
>    Ha (homersekletek[i] < 0)
>       Ha (van) akkor
>           Ha (homersekletek[i] > maxert)
>               maxind = i
>               maxert = homerseklete[i]
>           Elágazás vége
>       különben
>           van = igaz
>           maxind = i
>           maxert = homerseklete[i]
>       Elágazás vége
>   Elágazás vége
>Ciklus vége
>Ki: (van, maxind, maxert)
>```

>**Visszavezetés**
>```
>1..elemszám    ~   1..db
>elemek[i]      ~   homerseklet[i]
>T(elemek[i])   ~   homerseklet[i] < 0
>```

>**C# algoritmus**
>```csharp
>bool van = false;
>int maxind = -1;
>int maxert = -1;
>for (int i = 0; i < elemek.Length; i++) {
>    if (elemek[i] < 0)
>    {
>        if (van)
>        {
>            if (elemek[i] > elemek[maxind])
>            {
>                maxind = i;
>                maxert = elemek[i];
>            }
>        }
>        else
>        {
>            van = true;
>            maxind = i;
>            maxert = elemek[i];
>        }
>    }
>}
>if (van)
>{
>    Console.WriteLine($"Legnagyobb indexe: {maxind+1} ennek az értéke: {maxert}.");
>} else
>{
>    Console.WriteLine($"Sajnos nem volt a feltetelnek megfelelo elem.");
>}
>```
---

### Keresés

**Példa:** Volt-e valahány fok a korábbi hőmérsékleti adatainkban és ha igen mennyi?

>**Specifikáció**
>```
>Be: db∈N, elem∈N, homersekletek∈N[1..db]
>Ki: index∈N, van∈L
>Ef: -
>Uf: (van,index) = KERES(i=1..db, homersekletek[i] = elem)
>```

>**Pszeudokód**
>```
>i:Egész
>Be: homersekletek[db]
>i=1
>Ciklus amíg (i != db és homersekletek[i] != elem)
>   i = i + 1
>Ciklus vége
>Ha (i == db) akkor
>   van = hamis
>   Ki: van
>különben
>   van = igaz
>   Ki: (van, i)
>Elágazás vége
>```

>**Visszavezetés**
>```
>ind            ~   elem
>1..elemszám    ~   1..db
>T(elemek[i])   ~   homersekletek[i] == elem
>```

>**C# algoritmus**
>```csharp
>int i = 0;
>while ((i < elemek.Length) && elemek[i] != elem)
>    i++;
>if (i != elemek.Length)
>{
>    Console.WriteLine($"Igen volt még pedig itt: {i + 1}.");
>}
>else
>{
>    Console.WriteLine($"Sajnos nem volt ilyen elem!");
>}
>```
---

### Eldöntés

**Példa:** Egy természetes számról döntsük el, hogy prímszám-e!

>**Specifikáció**
>```
>Be: szam∈Z
>Ki: primszam∈L
>Ef: -
>Uf: primszam != VAN(i=2..szam-1,szam % i = 0)
>```
`Megj.: Specifikációban nem tudom hogyan kell jelölni, de elég a kért szám gyökéig elszámolni.`

>**Pszeudokód**
>```
>i:Egész
>primszam:Logikai
>Be:szam
>i=2
>Ciklus amíg (i <= gyok(szam) és szam mod i != 0)
>   i = i + 1
>Ciklus vége
>Ha (i > gyok(szam)) akkor
>   primszam = igaz
>Különben
>   primszam = hamis
>Elágazás vége
>Ki: primszam
>```

>**Visszavezetés**
>```
>van            ~   primszam
>1..elemszám    ~   2..gyok(szam)
>T(elemek[i])   ~   i mod szam = 0
>```

>**C# algoritmus**
>```csharp
>int szamGyoke = (int)Math.Sqrt(szam);
>int i = 2;
>while (i <= szamGyoke && szam % i != 0)
>    i++;
>return (i > szamGyoke);
>```

#### Mind eldöntés

**Példa:** Maradva az előző prímes példánál, döntsük el hogy egy tömb elemei mind prímszám-e vagy sem!
`Megj.: Primek() függvény előző példánál van definiálva, most megnézük minden elemre teljesül-e.`

>**Specifikáció**
>```
>Be: db∈N, szamok∈N[1..db]
>Ki: mind∈L
>Ef: -
>Uf: mind = MIND(i=1..db,(VAN(j=2..szamok[i]-1,szamok[i] % j = 0) = hamis))
>```

>**Pszeudokód**
>```
>i:Egész
>mind:Logikai
>Be:szamok[db]
>i=1
>Ciklus amíg (i != db és Primszam(szamok[i] = igaz))
>   i = i + 1
>Ciklus vége
>Ha (i == db) akkor
>   mind = igaz
>Különben
>   mind = hamis
>Elágazás vége
>Ki: mind
>```

>**Visszavezetés**
>```
>van            ~   mind
>1..elemszám    ~   1..db
>T(elemek[i])   ~   Primszam(szamok[i])
>```

>**C# algoritmus**
>```csharp
>int i = 0;
>while (i < szamok.Length && Primszam(szamok[i]))
>    i++;
>if(i == szamok.Length)
>{
>    Console.WriteLine("Valóban mind prímszám!");
>} else
>{
>    Console.WriteLine("Sajnos nem mind prímszám!");
>}
>```
---

### Kiválasztás

Kiválasztásnál **tudjuk**, hogy létezik az elem, csak éppen azt nem, hogy hol. Előfeltételben viszont fontos erről meggyőzödni, hogy valóban létezik-e az adott elem vagy annak az index-e. Ilyen egyébként a legtöbbnyelvben rendelkezésre álló IndexOf() függvény is.

**Példa:** Magyarkártyáknál kíváncsiak vagyunk egy adott kártya értékére.

>**Specifikáció**
>```
>Be: kártya∈S, kártyák∈S[1..8]=["VII", "VIII","IX","X","Alsó","Felső","Király","Ász"], értékek∈N[1..8]=[7,8,9,10,2,3,4,11]
>Ki: érték∈N, ind∈N
>Ef: létezik i eleme [1..8]: (kártya = kártyák[i])
>Uf: ind=KIVÁLASZT(i>=1,kártya=kártyák[i] és érték=értékek[ind])
>```

>**Pszeudokód**
>```
>Kártyák[8]: szöveg
>i: egész
>Be: kártya
>i:= 1
>Ciklus amíg (Kártyák[i] != kártya)
>     i := i + 1
>Ciklus vége
>Ki: i, Kártyák[i]
>```

>**Visszavezetés**
>```
>ind              ~   i
>T(elemek[ind])   ~   kártya=kártyák[i] és érték=értékek[ind] 
>```

>**C# algoritmus**
>```csharp
>string[] kartyak = new string[8] { "VII", "VIII", "IX", "X", "Also", "Felso", "Kiraly", "Asz" };
>int[] ertekek = new int[8] { 7, 8, 9, 10, 2, 3, 4, 11 };
>
>int i = 0;
>while(i < kartyak.Length && kartyak[i] != kartya)
>    i++;
>if(i != ertekek.Length)
>{
>    Console.WriteLine($"A {kartyak[i]} értéke: {ertekek[i]} és indexe: {i+1}");
>}
>else
>{
>    Console.WriteLine("Sajnos nem létezik ilyen kártya!");
>}
>```
---

### Másolás

**Példa:**

>**Specifikáció**
>```
>Be: db∈N,homC∈R[1..db]
>Ki: homF∈R[1..db]
>Fv: valt:R->R,
>    valt(celsius)=(celsius * 9/5 + 32)
>Ef: -
>Uf: homF=MÁSOL(i=1..db, valt(homC[i]))
>```

>**Pszeudokód**
>```
>i: egész
>Be: homC[db]
>homF[db]: Valós
>Ciklus i=1-től db-ig
>   homF[i]=(homC[i] * 9/5 + 32)
>Ciklus vége
>Ki: homF
>```

>**Visszavezetés**
>```
>fvelemek       ~   homF
>1..elemszám    ~   homC[1..db]
>f(elemek[i])   ~   valt(homC[i])
>```

>**C# algoritmus**
>```csharp
>double[] fahrenheitAdatok = new double[homerseklet.Length];
>for(int i = 0; i < homerseklet.Length; i++)
>{
>    fahrenheitAdatok[i] = (double)homerseklet[i] * 9/5 + 32;
>}
>return fahrenheitAdatok;
>```

`Megj.: Az egyszerűség kedvéért a korábban deklarált, egész számos hőmérsékleti adatokat konvertáljuk át. Lehetett volna valós a bemenet is feladat megoldáskor mindenképpen követni kell majd a specifikációt. (Tehát ha ott valós akkor legyen a kódban is az.)`

---

### Kiválogatás

**Példa:** Maradva az előző példánál, válogassuk most ki az X-nél nagyobb elemeket egy másik tömbbe!

>**Specifikáció**
>```
>Be: szam∈N,elemszam∈N,homF∈R[1..elemszam]
>Ki: db∈N,nagyobbXF∈R[1..db]
>Ef: -
>Uf: (db,nagyobbX)=KIVÁLOGAT(i=1..elemszam, homF[i] > szam,homF[i])
>```

>**Pszeudokód**
>```
>Be: homF[elemszam]: Valós
>nagyobbX[elemszam]: Valós
>i: egész
>db: Egész
>db = 1
>Ciklus i=1-től elemszam-ig
>   Ha (homF[i] > szam) akkor
>        nagyobbX[db] = homF[i]
>        db = db + 1
>    Elágazás vélge
>Ciklus vége
>Ki: nagyobbX
>```

>**Visszavezetés**
>```
>kivindexek     ~ nagyobb30F
>1..elemszám    ~ 1..elemszam
>T(elemek[i])   ~ homF[i] > szam
>i              ~ i
>```

>**C# algoritmus**
>```csharp
>double[] nagyobbX = new double[fahrenheit.Length];
>int db = 0;
>for (int i = 0; i < fahrenheit.Length; i++) 
>{
>    if (fahrenheit[i] > szam)
>    {
>        nagyobbX[db] = fahrenheit[i];
>        db++;
>    }
>}
>return nagyobbX;
>```

---

Egyelőre ennyi!