using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHTT
{
    public static class ConvTab
    {
    /* WIN 1251 */
    public static byte[] TOT =  {
	/* управляющие символы */
	/*        00            01            02            03            04            05            06            07            08           TAB            LF            0B            0C            CR            0E            0F */
	Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.WHITE, Consts.ENTER, Consts.INVAL, Consts.INVAL, Consts.WHITE, Consts.INVAL, Consts.INVAL,
	/*        10            11            12            13            14            15            16            17            18            19            1A            1B            1C            1D            1E            1F */
	Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL,
	/* пробел, знаки, цифры */
	/*        20             !             "             #             $             %             &             '             (             )             *             +             ,             -             .             / */
	Consts.WHITE, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.SITAL, Consts.CTEXT, Consts.SBOLD, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.COMMA, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,
	/*         0             1             2             3             4             5             6             7             8             9             :             ;             <             =             >             ? */
	Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.DIGIT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,

	/* прописные буквы, знаки */
	/*         @             A             B             C             D             E             F             G             H             I             J             K             L             M             N             O */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,
	/*  P      Q      R      S      T      U      V      W      X      Y      Z      [      \      ]      ^      _ */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.SCENT, Consts.CTEXT,

	/* строчные буквы, знаки */
	/*         `             a             b             c             d             e             f             g             h             i             j             k             l             m             n             o */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.SCENT, Consts.CTEXT,
	/*         p             q             r             s             t             u             v             w             x             y             z             {             |             }             ~               */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.ROWOP, Consts.CHEAD, Consts.ROWCL, Consts.INVAL, Consts.INVAL,

	/* русские или другие интернациональные символы */
	Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL,
    Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL, Consts.INVAL,
    /*                                                                                                                         Ё                                                                                                   */
    Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,
    /*                                                                                                                         ё                                                                                                   */
    Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,
	/*         А             Б             В             Г             Д             Е             Ж             З             И             Й             К             Л             М             Н             О             П */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,
	/*         Р             С             Т             У             Ф             Х             Ц             Ч             Ш             Щ             Ъ             Ы             Ь             Э             Ю             Я */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,
	/*         а             б             в             г             д             е             ж             з             и             й             к             л             м             н             о             п */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT,
	/*         р             с             т             у             ф             х             ц             ч             ш             щ             ъ             ы             ь             э             ю             я */
	Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT, Consts.CTEXT
    };
    }
}
