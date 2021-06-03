#from Members import Uyeler as uye
import csv
import errno
import os

baseProgramPath = "Programlar/"
days = [["Pazartesi"], ["Salı"], ["Çarşamba"], ["Perşembe"], ["Cuma"], ["Cumartesi"], ["Pazar"]]
csv.register_dialect('myDialect', delimiter='|', quoting=csv.QUOTE_NONE, skipinitialspace=True, quotechar='')


class Program:
	@staticmethod
	def netYagHesaplama(cinsiyet: str, boy: float, kilo: float) -> float:
		"""
		Bir üyenin vücudundaki net yağ miktarının yaklaşık olarak
		hesaplanması için hazırlana metod

		:param cinsiyet: Yaklaşık yağ oranı hesaplanacak üyenin cinsiyeti
		:type cinsiyet: str
		:param boy: Yaklaşık yağ oranı hesaplanacak üyenin boyu(cm)
		:type boy: float
		:param kilo: Yaklaşık yağ oranı hesaplanacak üyenin vücut ağırlığı(kg)
		:type kilo:float
		:return: Yaklaşık olarak hesaplanan yağ miktarı(kg)
		:rtype: float
		"""
		return kilo - Program.yagsizKiloHesapla(cinsiyet, boy, kilo)

	@staticmethod
	def yagsizKiloHesapla(cinsiyet: str, boy: float, kilo: float) -> float:
		"""
		Bir üyenin vücudunun yağsız ağırlığının yaklaşık olarak hesaplanması için hazırlanan metod

		Erkek : (1.10 * Ağırlık (kg)) - 128 * (Ağırlık2/(100 * Boy(m))2)
		Kadın : (1.07 * Ağırlık (kg)) - 148 * (Ağırlık2/(100 * Boy(m))2)

		:param cinsiyet: Yaklaşık olarak yağsız vücut ağırlığı hesaplanacak üyenin cinsiyeti
		:type cinsiyet: str
		:param boy: Yaklaşık olarak yağsız vücut ağırlığı hesaplanacak üyenin boyu(cm)
		:type boy: float
		:param kilo: Yaklaşık olarak yağsız vücut ağırlığı hesaplanacak üyenin vücut ağırlığı(kg)
		:type kilo:float
		:return: Yaklaşık olarak hesaplanan net yağ oranı
		:rtype: float
		"""
		if (cinsiyet == 0):  # erkek
			return (kilo * (1.10)) - 128 * ((kilo ** 2) / boy ** 2)
		else:  # kadın
			return ((1.07) * kilo) - 148 * ((kilo ** 2) / boy ** 2)

	@staticmethod
	def boyKiloEndeks(boy: float, kilo: float) -> str:
		"""
		Bir üyenin vücut kitle indeksinin hesaplanması için hazırlanan metod

		:param boy: Vücut kitle indeksi hesaplanacak üyenin boyu(cm)
		:type boy: float
		:param kilo: Vücut kitle indeksi hesaplanacak üyenin vücut ağırlığı(kg)
		:type kilo: flaot
		:return: Vücut kitle endeksini hesaplayıp uygun mesajı döner.
		:rtype: str
		"""
		bmi = kilo / ((boy / 100) ** 2)
		# "My name is {fname}, I'm {age}".format(fname = "John", age = 36)
		if (bmi < 18.5):
			return f"Vücut kitle endeksiniz: {bmi:.2f}, zayıfsınız."
		elif (bmi < 25):
			return f"Vücut kitle endeksiniz: {bmi:.2f}, normalsiniz."
		elif (bmi < 30):
			return f"Vücut kitle endeksiniz: {bmi:.2f}, fazla kilolusunuz."
		elif (bmi < 35):
			return f"Vücut kitle endeksiniz: {bmi:.2f}, Şişmansınız(1. derece obez)."
		elif (bmi < 45):
			return f"Vücut kitle endeksiniz: {bmi:.2f}, Şişmansınız(2. derece obez)."
		elif (45 < bmi):
			return f"Vücut kitle endeksiniz: {bmi:.2f}, Aşırı şişmansınız(3. derece obez), sağlığınız tehlikede."

	@staticmethod
	def programSil(Id: str):
		"""
		Bir üyenin spor programını diskten silmek için hazırlanan metod

		:param Id: Kimlik numarası
		:type Id: str
		"""
		try:
			os.remove("Programlar/" + Id + ".csv")
		except Exception as e:
			print('Silme hatası: ' % e)

	@staticmethod
	def programYaz(prog: list, Id: str):
		"""
		Bir üyenin spor programının diske yazımı için hazırlanan metod

		:param prog: Diske yazılacak spor programı
		:type prog: list
		:param Id: Kimlik numarası
		:type Id: str
		"""
		with open(baseProgramPath + Id + ".csv", mode='w', encoding='utf-8', newline='') as writeFile:
			writer = csv.writer(writeFile, 'myDialectp')
			semicolon = [';']
			for ind, row in enumerate(prog):
				writer.writerow(days[ind])
				writer.writerow(row)
				writer.writerow(semicolon)

	@staticmethod
	def programOku(Id: str) -> str:
		"""
		Bir üyenin spor programını diskten okumak için hazırlanan metod

		Diskten listeye okunana spor programı string haline getirilir.
		Listeden stringe dönerken gelen gereksiz karakterler metinden temizlenir.

		:param Id: Kimlik numarası
		:type Id: str
		:return: Sppr programı
		:rtype: str
		"""
		liste = []
		prog = []

		try:
			with open(baseProgramPath+Id+".csv", mode='r', encoding='utf-8') as readerFile:
				reader = csv.reader(readerFile, 'myDialectp')
				for row in reader:
					liste.append(row)

				for ind, row in enumerate(liste):
					if row in days:
						liste.pop(ind)

				temp = ""
				count = 0

				for ind, row in enumerate(liste):
					if ';' in row:
						for i in range(count, ind):
							temp += str(liste[i])
							if i < ind -1:
								temp += "*"
						prog.append(temp)
						count = ind + 1
						temp = ""

				prog = '|'.join(str(elem) for elem in prog)

				# Listeden stringe dönerken gelen gereksiz karakterler metinden temizlenir.
				prog = prog.replace('[', '')
				prog = prog.replace('\'', '')
				prog = prog.replace(']', '')
				prog = prog.replace(' ', ';')

		except OSError as exc: # Eğer Programlar klasörü bulunamazsa
			if exc.errno != errno.EEXIST:
				os.mkdir(os.getcwd() + "/Programlar/")

		return prog
