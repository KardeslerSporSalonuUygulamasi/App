#from Members import Uyeler as uye
import csv

csv.register_dialect('myDialect', delimiter='|', quoting=csv.QUOTE_NONE, skipinitialspace=True, quotechar='')


class Program:
	# def __init__(self, Id, kosuMesefesi, kalori, saat, katilim, yagOrani):
	#     self.Id = Id
	#     self.kosuMesafesi = kosuMesefesi
	#     self.kalori = kalori
	#     self.saat = saat
	#     self.katilim = katilim
	#     self.yagOrani = yagOrani

	def yagsizKiloHesapla(self, cins, boy, kilo) -> float:
		if (cins == 0):  # erkek
			return (kilo * (1.10)) - 128 * ((kilo ** 2) / boy ** 2)
		else:  # kadın
			return ((1.07) * kilo) - 148 * ((kilo ** 2) / boy ** 2)

	def kaloriYakmaHesapla(self, kosuMesafesi, kilo) -> float:
		return kosuMesafesi * kilo * (0.781)

	def boyKiloEndeks(self, boy, kilo) -> float:
		bmi = kilo / ((boy / 100) ** 2)
		# "My name is {fname}, I'm {age}".format(fname = "John", age = 36)
		if (bmi < 18.5):
			return "Vücut kitle endeksiniz: {bmi}, zayıfsınız."
		elif (bmi < 25):
			return "Vücut kitle endeksiniz: {bmi}, normalsiniz."
		elif (bmi < 30):
			return "Vücut kitle endeksiniz: {bmi}, fazla kilolusunuz."
		elif (bmi < 35):
			return "Vücut kitle endeksiniz: {bmi}, şişmansınız(1. derece obez)."
		elif (bmi < 45):
			return "Vücut kitle endeksiniz: {bmi}, şişmansınız(2. derece obez)."
		elif (45 < bmi):
			return "Vücut kitle endeksiniz: {bmi}, aşırı şişmansınız(3. derece obez), sağlığınız tehlikede."

	def netYagHesaplama(self, cins, kilo, boy) -> float:
		return kilo - Program.yagsizKiloHesapla(cins, boy, kilo)#parametreleri kıyasla

	# def rapor():

	def programYaz(prog, Id):  # bir programı dosyaya yazımı
		liste = []
		liste.append(prog)
		print('py liste ', liste)
		with open(Id+".csv", mode='w', encoding='utf-8', newline='') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerows(liste)

	@staticmethod
	def programOku(Id):  # program listesinin okunması
		liste = []
		with open(Id+".csv", mode='r', encoding='utf-8') as readerFile:
			reader = csv.reader(readerFile, 'myDialect')
			for row in reader:
				liste.append(row)
		# liste.extend(row)
		return liste
