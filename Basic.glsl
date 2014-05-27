//version 330 inserted here by shader precompiler

#ifdef _VERTEX_
	uniform mat4 modelview_matrix;            
	uniform mat4 projection_matrix;
	
	in vec3 vertex_position;
	in vec2 vertex_uv;
	in vec3 vertex_normal;
	in float vertex_ao;
	
	out vec3 normal;
	out vec4 position;
	out float ao;
	
	void main(void)
	{
		normal = ( modelview_matrix * vec4( vertex_normal, 0 ) ).xyz;
		position = projection_matrix * modelview_matrix * vec4( vertex_position, 1 );
		ao = vertex_ao;
		gl_Position = position;
	}
#endif

#ifdef _FRAGMENT_
	precision highp float;
	
	const vec3 ambient = vec3( 0.1, 0.1, 0.1 );
	const vec3 lightVecNormalized = normalize( vec3( 0.5, 0.5, 2 ) );
	const vec3 lightColor = vec3( 0.7, 0.7, 0.7 );
	const vec3 lightColorRefl = vec3( 1.0, 0.0, 0.0 );
	
	in vec3 normal;
	in vec4 position;
	in float ao;
	
	out vec4 out_frag_color;
	
	void main(void)
	{
	float diffuse = clamp( dot( lightVecNormalized, normalize( normal ) ), 0.0, 1.0 );
	float diffuseRefl = clamp( dot( lightVecNormalized, normalize( -normal ) ), 0.0, 1.0 );
	out_frag_color = vec4( ambient + (diffuse * lightColor + diffuseRefl*lightColorRefl)*ao, 1.0 );
	}
#endif
