PGDMP     *    6                 z            case    14.5    14.5                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16394    case    DATABASE     c   CREATE DATABASE "case" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE "case";
                postgres    false            ?            1259    24587    BasketProducts    TABLE     ?   CREATE TABLE public."BasketProducts" (
    id integer NOT NULL,
    count integer,
    basket_id integer,
    productid integer
);
 $   DROP TABLE public."BasketProducts";
       public         heap    postgres    false            ?            1259    24586    BasketProducts_id_seq    SEQUENCE     ?   ALTER TABLE public."BasketProducts" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."BasketProducts_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            ?            1259    24598    Baskets    TABLE     y   CREATE TABLE public."Baskets" (
    id integer NOT NULL,
    campaign_id integer,
    coupon_code text,
    guid text
);
    DROP TABLE public."Baskets";
       public         heap    postgres    false            ?            1259    16402 	   Campaigns    TABLE     ?  CREATE TABLE public."Campaigns" (
    id integer NOT NULL,
    name text,
    campaign_type_id integer NOT NULL,
    discount_rate integer,
    campaign_conditions_id integer NOT NULL,
    condition_which_products integer[],
    condition_product_count integer,
    condition_basket_price integer,
    campaign_effect_id integer NOT NULL,
    effect_which_products integer[],
    effect_product_count integer,
    coupon text
);
    DROP TABLE public."Campaigns";
       public         heap    postgres    false            ?            1259    16395    Products    TABLE     g   CREATE TABLE public."Products" (
    id integer NOT NULL,
    name text,
    price double precision
);
    DROP TABLE public."Products";
       public         heap    postgres    false            ?            1259    24597    baskets_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.baskets_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.baskets_id_seq;
       public          postgres    false    217                       0    0    baskets_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.baskets_id_seq OWNED BY public."Baskets".id;
          public          postgres    false    216            ?            1259    16416    campaingConditionTypes    TABLE     ^   CREATE TABLE public."campaingConditionTypes" (
    id integer NOT NULL,
    condition text
);
 ,   DROP TABLE public."campaingConditionTypes";
       public         heap    postgres    false            ?            1259    16423    campaingEffectTypes    TABLE     X   CREATE TABLE public."campaingEffectTypes" (
    id integer NOT NULL,
    effect text
);
 )   DROP TABLE public."campaingEffectTypes";
       public         heap    postgres    false            ?            1259    16409    campaingTypes    TABLE     P   CREATE TABLE public."campaingTypes" (
    id integer NOT NULL,
    type text
);
 #   DROP TABLE public."campaingTypes";
       public         heap    postgres    false            u           2604    24601 
   Baskets id    DEFAULT     j   ALTER TABLE ONLY public."Baskets" ALTER COLUMN id SET DEFAULT nextval('public.baskets_id_seq'::regclass);
 ;   ALTER TABLE public."Baskets" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    216    217    217                      0    24587    BasketProducts 
   TABLE DATA           K   COPY public."BasketProducts" (id, count, basket_id, productid) FROM stdin;
    public          postgres    false    215   '"                 0    24598    Baskets 
   TABLE DATA           G   COPY public."Baskets" (id, campaign_id, coupon_code, guid) FROM stdin;
    public          postgres    false    217   ?"                 0    16402 	   Campaigns 
   TABLE DATA           ?   COPY public."Campaigns" (id, name, campaign_type_id, discount_rate, campaign_conditions_id, condition_which_products, condition_product_count, condition_basket_price, campaign_effect_id, effect_which_products, effect_product_count, coupon) FROM stdin;
    public          postgres    false    210   #                 0    16395    Products 
   TABLE DATA           5   COPY public."Products" (id, name, price) FROM stdin;
    public          postgres    false    209   ?%                 0    16416    campaingConditionTypes 
   TABLE DATA           A   COPY public."campaingConditionTypes" (id, condition) FROM stdin;
    public          postgres    false    212   ?&                 0    16423    campaingEffectTypes 
   TABLE DATA           ;   COPY public."campaingEffectTypes" (id, effect) FROM stdin;
    public          postgres    false    213   n'                 0    16409    campaingTypes 
   TABLE DATA           3   COPY public."campaingTypes" (id, type) FROM stdin;
    public          postgres    false    211   ?'                  0    0    BasketProducts_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."BasketProducts_id_seq"', 35, true);
          public          postgres    false    214                        0    0    baskets_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.baskets_id_seq', 3, true);
          public          postgres    false    216            ?           2606    24593 "   BasketProducts BasketProducts_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."BasketProducts"
    ADD CONSTRAINT "BasketProducts_pkey" PRIMARY KEY (id);
 P   ALTER TABLE ONLY public."BasketProducts" DROP CONSTRAINT "BasketProducts_pkey";
       public            postgres    false    215            ?           2606    24603    Baskets baskets_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Baskets"
    ADD CONSTRAINT baskets_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public."Baskets" DROP CONSTRAINT baskets_pkey;
       public            postgres    false    217            }           2606    16422 .   campaingConditionTypes campaingConditions_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public."campaingConditionTypes"
    ADD CONSTRAINT "campaingConditions_pkey" PRIMARY KEY (id);
 \   ALTER TABLE ONLY public."campaingConditionTypes" DROP CONSTRAINT "campaingConditions_pkey";
       public            postgres    false    212                       2606    16429 ,   campaingEffectTypes campaingEffectTypes_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."campaingEffectTypes"
    ADD CONSTRAINT "campaingEffectTypes_pkey" PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public."campaingEffectTypes" DROP CONSTRAINT "campaingEffectTypes_pkey";
       public            postgres    false    213            {           2606    16415     campaingTypes campaingTypes_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."campaingTypes"
    ADD CONSTRAINT "campaingTypes_pkey" PRIMARY KEY (id);
 N   ALTER TABLE ONLY public."campaingTypes" DROP CONSTRAINT "campaingTypes_pkey";
       public            postgres    false    211            y           2606    16408    Campaigns campaings_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Campaigns"
    ADD CONSTRAINT campaings_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public."Campaigns" DROP CONSTRAINT campaings_pkey;
       public            postgres    false    210            w           2606    16399    Products products_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public."Products" DROP CONSTRAINT products_pkey;
       public            postgres    false    209               ?   x?-??1?V1?C??%????a`?}Y??l?j???0????t??F??՘?-??G@X???^????R?k}]{?|???R?A?'xԹ`
^??r?_m?qW?!??"xG???}??c(?? ?H'?         D   x????0 ?7?BF
6a?????1?????B5???L???"??+?;????9??T??         ?  x??T?n?0???x?7? %ю?vth? Zh?1?T ;??@??D[?]?%?7Y??/??(?v?؃eJ"??pD|N????Ff
?޿T??U?eKx{?q?f0??Q??S
????'?d,ւ??F???x??m?????!	@?re?dU(????Z?????QJFnI?0???T???$??~?I??X?\???b?????}?,wz{y?r??adN??H?{,??UZ?aC??=)??&???JK掯?U!2l??o??r?Ң?}?CD=n??uK?}KT>?}??F&??r>??E???????i??T??T?`"?U?mv????21Z?ЊX?eu?[?????m?*L,?/?*dV????wpj*???5Sy?p^???^ٕZ?.?Z?$?????P؀)fy!x?q??X??Dh}9?q????z?E??EY?.???s#??^??/???]B???m?"s???h5???A???I\???o%^??	|???w]??|??VL?@??;??(??w???u??Om???.?A;bC???1x??E??SI??ҲN???l@??H?~??-F??ɝ4
=?%?*!ǻ?C??p?pl?d??r
??8;?"ޅqv^????t?6????H?Z??ڠh?????S         ,  x?UP?N?0??Oq/ ??uJWR$X?X\խ?8	rS???dd?K?lNދs?*u????>???cn??z?JJ?z?I?@8ر?]?5???	&???3x3޴??L`?Rb???O??i??b$?P?=?ڻ?x?J?H!?:~ Qb??7?V???!2?r?k?????"("H?%??^ٶnl?w????H??$?r????YȌ?e\n??4%O\^NO? ???mW6F?2oJ????v:?C\????p?]ΰ9?????A??L?????i<v+~?
0v@?K!cNw?X?z_?-?????B?????         p   x?e?K
?0??)z?B?i/S??H?e?	??͢?E?3s!?P$??W???|?????n-f?T]?	EM?X???x?S?Q??8.??h??Oz?!*??$Y?j?י??Y?6?         #   x?3?,ɏOJ,?N-?2???SJ?K?b???? ?V	1         B   x?E?;?@??w??1? L??pK????2??Б?Ai%?ͺ^???E2?j8)k??{o >T?x     