# Programozási tételek

Segédanyag az ***IK-19fszPAEG** (2024/25/1)* [ELTE](https://www.inf.elte.hu/) tantárgyához.
[Specifikáció Készítő](https://progalapfsz.elte.hu/specifikacio/)
[C# leírás angol nyelven (tutorialspoint)](https://www.tutorialspoint.com/csharp/index.htm)

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

**Példa:**

>**Specifikáció**
>```

>```

>**Pszeudokód**
>```

>```

>**Visszavezetés**
>```

>```

>**C# algoritmus**
>```csharp
>int i = 0;
>while (i < primek.Length && Primszam(primek[i]))
>    i++;
>if(i == primek.Length)
>{
>    Console.WriteLine("Valóban mind prímszám!");
>} else
>{
>    Console.WriteLine("Sajnos nem mind prímszám!");
>}
>```
---

### Kiválasztás

**Példa:**

>**Specifikáció**
>```

>```

>**Pszeudokód**
>```

>```

>**Visszavezetés**
>```

>```

>**C# algoritmus**
>```csharp

>```
---

### Másolás

**Példa:**

>**Specifikáció**
>```

>```

>**Pszeudokód**
>```

>```

>**Visszavezetés**
>```

>```

>**C# algoritmus**
>```csharp

>```
---

### Kiválogatás

**Példa:**

>**Specifikáció**
>```

>```

>**Pszeudokód**
>```

>```

>**Visszavezetés**
>```

>```

>**C# algoritmus**
>```csharp

>```
---

Egyelőre ennyi!