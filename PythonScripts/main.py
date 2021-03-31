import sys

class Uyeler:


    salonAdi="Kardeşler Spor Salonu"

    def __init__(self, Id, adSoyad, yas, kilo, dogumTarihi):
        self.Id = Id
        self.adSoyad = adSoyad
        self.yas = yas
        self.kilo = kilo
        self.dogumTarihi = dogumTarihi

    def yazma(self):
        liste = [str(self.Id),"\t", self.adSoyad,"\t", self.yas,"\t", self.kilo,"\t", str(self.dogumTarihi)]
        with open("uyeTablo.txt", 'w', encoding = 'utf-8') as dosya:

            #dosya.write("#")
            dosya.writelines(liste)
            #dosya.writeline(self.id, self.adSoyad, self.yas, self.kilo, self.dogumTarihi)

    def uyeBilgileri(self):
       print("Salon Adı: ",uye.salonAdi,"\nTC :",self.Id,
              "\nİsim Soyisim :",self.adSoyad,
              "\nYaş : ",self.yas,
              "\nKilo : ",self.kilo,
              "\nDogum Tarihi: ",self.dogumTarihi)
    #def uyeKaydet(self):



#arada # işareti var değerleri alırken kullanacağımız!

uye=Uyeler("1","Yasin Işıktaş","24","70","07.01.1997")
uye.yazma()

for arg in sys.argv:
    print(arg)
